using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace PriAndWf.Infrastructure.Helper
{
    public static class CodeExecuteTimeHelper
    {
        #region LoadLibrary/GetProcAddress/FreeLibrary
        ///// <summary>
        ///// 装载动态链接库
        ///// 原型 : HMODULE LoadLibrary(LPCTSTR lpFileName);
        ///// </summary>
        ///// <param name="lpFileName">动态链接库文件名（查找顺序 : 程序当前目录->System32目录->环境变量Path所设置路径）</param>
        ///// <returns>函数库模块的句柄</returns>
        //[DllImport("kernel32.dll")]
        //static extern IntPtr LoadLibrary(string lpFileName);
        //[DllImport("kernel32.dll")]
        //static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);
        ///// <summary>
        ///// 获取要引入的函数
        ///// 原型 : FARPROC GetProcAddress(HMODULE hModule, LPCWSTR lpProcName);
        ///// </summary>
        ///// <param name="hModule">函数库模块的句柄</param>
        ///// <param name="lpProcName">调用函数的名称</param>
        ///// <returns>函数指针</returns>
        //[DllImport("kernel32.dll")]
        //static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        ///// <summary>
        ///// 释放动态链接库
        ///// 原型 : BOOL FreeLibrary(HMODULE hModule);
        ///// </summary>
        ///// <param name="hModule">需要释放的“函数库模块的句柄”</param>
        ///// <returns>是否释放指定的动态链接库</returns>
        //[DllImport("kernel32.dll")]
        //static extern bool FreeLibrary(IntPtr hModule);
        #endregion

        #region QueryThreadCycleTime
        ///// <summary>
        ///// 获取指定线程的时间信息
        ///// 原型 : BOOL QueryThreadCycleTime(HANDLE ThreadHandle,PULONG64 CycleTime);
        ///// 备注 : Windows Vista 、 Windows Server 2008
        ///// </summary>
        ///// <param name="threadHandle">线程句柄</param>
        ///// <param name="cycleTime">“内核时间”和“用户时间”的总和</param>
        ///// <returns>是否获取到指定线程的时间信息</returns>
        //[DllImport("kernel32.dll")]
        //static extern bool QueryThreadCycleTime(IntPtr threadHandle, ref ulong cycleTime);
        #endregion

        #region GetCurrentThread/GetThreadTimes
        ///// <summary>
        ///// 获取当前线程的“虚拟句柄（伪句柄）”
        ///// 原型 : HANDLE GetCurrentThread();
        ///// 备注 : Windows XP 、 Windows Server 2003 、 Windows Phone 8
        ///// </summary>
        ///// <returns>当前线程伪句柄</returns>
        //[DllImport("kernel32.dll")]
        //static extern IntPtr GetCurrentThread();

        ///// <summary>
        ///// 获取指定线程的时间信息
        ///// 原型 : BOOL GetThreadTimes(HANDLE hThread,LPFILETIME lpCreationTime,LPFILETIME lpExitTime,LPFILETIME lpKernelTime,LPFILETIME lpUserTime);
        ///// 备注 : Windows XP 、 Windows Server 2003
        ///// </summary>
        ///// <param name="hThread">线程句柄</param>
        ///// <param name="lpCreationTime">创建时间</param>
        ///// <param name="lpExitTime">退出时间</param>
        ///// <param name="lpKernelTime">内核时间</param>
        ///// <param name="lpUserTime">用户时间</param>
        ///// <returns>是否获取到指定线程的时间信息</returns>
        //[DllImport("kernel32.dll")]
        //static extern bool GetThreadTimes(IntPtr hThread, out long lpCreationTime, out long lpExitTime, out long lpKernelTime, out long lpUserTime);
        #endregion

        #region GetTickCount
        ///// <summary>
        ///// 获取时钟的计数
        ///// 原型 : DWORD GetTickCount();
        ///// 备注 : Windows 2000 、 Windows Server 2000
        ///// </summary>
        ///// <returns></returns>
        //[DllImport("kernel32.dll")]
        //static extern long GetTickCount();
        #endregion


        /// <summary>
        /// 获取“性能计数器”的计数（前提 : 假设线程不被抢占）
        /// 原型 : BOOL QueryPerformanceCounter(LARGE_INTEGER *lpPerformanceCount);
        /// 备注 : Windows 2000 、 Windows Server 2000 、 Windows Phone 8
        /// </summary>
        /// <param name="lpPerformanceCount">“性能计数器”的计数</param>
        /// <returns>硬件是否支持“性能计数器”</returns>
        [DllImport("kernel32.dll")]
        static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        /// <summary>
        /// 获取“性能计数器”的频率（前提 : 假设线程不被抢占）
        /// 原型 : BOOL QueryPerformanceFrequency(LARGE_INTEGER *lpFrequency);
        /// 备注 : Windows 2000 、 Windows Server 2000 、 Windows Phone 8
        /// </summary>
        /// <param name="lpFrequency">“性能计数器”的频率</param>
        /// <returns>硬件是否支持“性能计数器”</returns>
        [DllImport("kernel32.dll")]
        static extern bool QueryPerformanceFrequency(out long lpFrequency);

        static long frequency, start, end;
        static CodeExecuteTimeHelper()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            if (!QueryPerformanceFrequency(out frequency))
            {
                throw new Win32Exception("硬件不支持“性能计数器”.");
            }
        }

        public static CodeExecuteTime Time(Action action, int iteration = 10000)
        {
            iteration = (iteration <= 0 ? 1 : iteration);

            Dictionary<decimal, int> executeTimes = new Dictionary<decimal, int>();
            List<int> gcCollectionCounts = new List<int>();

            decimal s;

            GC.Collect(GC.MaxGeneration);//强制 GC 进行收集，并记录目前各代已经收集的次数

            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                gcCollectionCounts.Add(GC.CollectionCount(i));
            }
            #region 执行方法
            //耗时代码
            for (int i = 0; i < iteration; i++)
            {
                QueryPerformanceCounter(out start);//start
                action();
                QueryPerformanceCounter(out end);//end
                s = (((decimal)end - (decimal)start) / (decimal)frequency);
                if (executeTimes.ContainsKey(s))
                {
                    executeTimes[s] = executeTimes[s] + 1;
                }
                else
                {
                    executeTimes.Add(s, 1);
                }
            }
            #endregion
            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                gcCollectionCounts[i] = GC.CollectionCount(i) - gcCollectionCounts[i];
            }
            return new CodeExecuteTime(executeTimes, gcCollectionCounts);
        }

        public class CodeExecuteTime
        {
            public Dictionary<decimal, int> ExecuteTimes { get; private set; }
            public List<int> GcCollectionCounts { get; private set; }

            public decimal GetExFirstLastAvg
            {
                get
                {
                    decimal sum = ExecuteTimes.Sum(m => m.Key * m.Value);
                    int count = ExecuteTimes.Sum(m => m.Value);
                    if (ExecuteTimes.Count >= 3)
                    {
                        var first = ExecuteTimes.First();
                        sum -= first.Key * first.Value;
                        count -= first.Value;
                        var last = ExecuteTimes.Last();
                        sum -= last.Key * last.Value;
                        count -= last.Value;
                    }
                    var avg = sum / count;
                    return avg;
                }
            }

            internal CodeExecuteTime(Dictionary<decimal, int> executeTimes, List<int> gcCollectionCounts)
            {
                ExecuteTimes = executeTimes;
                GcCollectionCounts = gcCollectionCounts;
            }
        }
    }
}
