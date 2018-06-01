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
        #region 1.GetTickCount（前提 : 线程执行不被中断）
        /// <summary>
        /// 获取时钟的计数
        /// 原型 : DWORD GetTickCount();
        /// 备注 : Windows 2000 、 Windows Server 2000
        /// </summary>
        /// <returns>时钟的计数</returns>
        //[DllImport("kernel32.dll")]
        //static extern long GetTickCount();
        #endregion

        #region 2.GetThreadTimes/GetCurrentThread
        /// <summary>
        /// 获取指定线程的时间信息
        /// 原型 : BOOL GetThreadTimes(HANDLE hThread,LPFILETIME lpCreationTime,LPFILETIME lpExitTime,LPFILETIME lpKernelTime,LPFILETIME lpUserTime);
        /// 备注 : Windows XP 、 Windows Server 2003
        /// </summary>
        /// <param name="hThread">线程句柄</param>
        /// <param name="lpCreationTime">创建时间</param>
        /// <param name="lpExitTime">退出时间</param>
        /// <param name="lpKernelTime">内核时间</param>
        /// <param name="lpUserTime">用户时间</param>
        /// <returns>是否获取到指定线程的时间信息</returns>
        //[DllImport("kernel32.dll")]
        //static extern bool GetThreadTimes(IntPtr hThread, out long lpCreationTime, out long lpExitTime, out long lpKernelTime, out long lpUserTime);
        /// <summary>
        /// 获取当前线程的“虚拟句柄（伪句柄）”
        /// 原型 : HANDLE GetCurrentThread();
        /// 备注 : Windows XP 、 Windows Server 2003 、 Windows Phone 8
        /// </summary>
        /// <returns>当前线程伪句柄</returns>
        //[DllImport("kernel32.dll")]
        //static extern IntPtr GetCurrentThread();
        #endregion

        #region 3.QueryThreadCycleTime
        /// <summary>
        /// 获取指定线程的时间信息
        /// 原型 : BOOL QueryThreadCycleTime(HANDLE ThreadHandle,PULONG64 CycleTime);
        /// 备注 : Windows Vista 、 Windows Server 2008
        /// </summary>
        /// <param name="threadHandle">线程句柄</param>
        /// <param name="cycleTime">“内核时间”和“用户时间”的总和</param>
        /// <returns>是否获取到指定线程的时间信息</returns>
        //[DllImport("kernel32.dll")]
        //static extern bool QueryThreadCycleTime(IntPtr threadHandle, ref ulong cycleTime);
        #endregion

        #region 4.QueryPerformanceCounter/QueryPerformanceFrequency（前提 : 假设线程不被抢占）
        /// <summary>
        /// 获取“性能计数器”的计数
        /// 原型 : BOOL QueryPerformanceCounter(LARGE_INTEGER *lpPerformanceCount);
        /// 备注 : Windows 2000 、 Windows Server 2000 、 Windows Phone 8
        /// </summary>
        /// <param name="lpPerformanceCount">“性能计数器”的计数</param>
        /// <returns>硬件是否支持“性能计数器”</returns>
        [DllImport("kernel32.dll")]
        static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        /// <summary>
        /// 获取“性能计数器”的频率
        /// 原型 : BOOL QueryPerformanceFrequency(LARGE_INTEGER *lpFrequency);
        /// 备注 : Windows 2000 、 Windows Server 2000 、 Windows Phone 8
        /// </summary>
        /// <param name="lpFrequency">“性能计数器”的频率</param>
        /// <returns>硬件是否支持“性能计数器”</returns>
        [DllImport("kernel32.dll")]
        static extern bool QueryPerformanceFrequency(out long lpFrequency);
        #endregion

        static CodeExecuteTimeHelper()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
        }

        //public static CodeExecuteTime TimeByGetTickCount(Action action, int iteration = 10000)
        //{
        //    long frequency = 1000;//1毫秒
        //    iteration = (iteration <= 0 ? 1 : iteration);

        //    Dictionary<decimal, int> executeTimes = new Dictionary<decimal, int>();
        //    List<int> gcCollectionCounts = new List<int>();

        //    long start, end;
        //    decimal second;

        //    GC.Collect(GC.MaxGeneration);//强制 GC 进行收集，并记录目前各代已经收集的次数

        //    for (int i = 0; i <= GC.MaxGeneration; i++)
        //    {
        //        gcCollectionCounts.Add(GC.CollectionCount(i));
        //    }
        //    #region 执行方法
        //    for (int i = 0; i < iteration; i++)
        //    {
        //        start = GetTickCount();//start
        //        action();
        //        end = GetTickCount();//end
        //        second = (((decimal)end - (decimal)start) / (decimal)frequency);
        //        if (executeTimes.ContainsKey(second))
        //        {
        //            executeTimes[second] = executeTimes[second] + 1;
        //        }
        //        else
        //        {
        //            executeTimes.Add(second, 1);
        //        }
        //    }
        //    #endregion
        //    for (int i = 0; i <= GC.MaxGeneration; i++)
        //    {
        //        gcCollectionCounts[i] = GC.CollectionCount(i) - gcCollectionCounts[i];
        //    }
        //    return new CodeExecuteTime(executeTimes, gcCollectionCounts);
        //}
        //public static CodeExecuteTime TimeByGetThreadTimes(Action action, int iteration = 10000)
        //{
        //    long frequency = 10000000;//100纳秒
        //    iteration = (iteration <= 0 ? 1 : iteration);

        //    Dictionary<decimal, int> executeTimes = new Dictionary<decimal, int>();
        //    List<int> gcCollectionCounts = new List<int>();

        //    long start, end;
        //    decimal second;

        //    IntPtr hThread = GetCurrentThread();
        //    long lpCreationTimeS, lpExitTimeS, lpKernelTimeS, lpUserTimeS;
        //    long lpCreationTimeE, lpExitTimeE, lpKernelTimeE, lpUserTimeE;

        //    GC.Collect(GC.MaxGeneration);//强制 GC 进行收集，并记录目前各代已经收集的次数

        //    for (int i = 0; i <= GC.MaxGeneration; i++)
        //    {
        //        gcCollectionCounts.Add(GC.CollectionCount(i));
        //    }
        //    #region 执行方法
        //    for (int i = 0; i < iteration; i++)
        //    {
        //        GetThreadTimes(hThread, out lpCreationTimeS, out lpExitTimeS, out lpKernelTimeS, out lpUserTimeS);//start
        //        action();
        //        GetThreadTimes(hThread, out lpCreationTimeE, out lpExitTimeE, out lpKernelTimeE, out lpUserTimeE);//end
        //        start = lpKernelTimeS + lpUserTimeS;
        //        end = lpKernelTimeE + lpUserTimeE;
        //        second = (((decimal)end - (decimal)start) / (decimal)frequency);
        //        if (executeTimes.ContainsKey(second))
        //        {
        //            executeTimes[second] = executeTimes[second] + 1;
        //        }
        //        else
        //        {
        //            executeTimes.Add(second, 1);
        //        }
        //    }
        //    #endregion
        //    for (int i = 0; i <= GC.MaxGeneration; i++)
        //    {
        //        gcCollectionCounts[i] = GC.CollectionCount(i) - gcCollectionCounts[i];
        //    }
        //    return new CodeExecuteTime(executeTimes, gcCollectionCounts);
        //}
        //public static CodeExecuteTime TimeByQueryThreadCycleTime(Action action, int iteration = 10000)
        //{
        //    long frequency = 10000000;//100纳秒
        //    iteration = (iteration <= 0 ? 1 : iteration);

        //    Dictionary<decimal, int> executeTimes = new Dictionary<decimal, int>();
        //    List<int> gcCollectionCounts = new List<int>();

        //    ulong start = 0, end = 0;
        //    decimal second;

        //    IntPtr hThread = GetCurrentThread();

        //    GC.Collect(GC.MaxGeneration);//强制 GC 进行收集，并记录目前各代已经收集的次数

        //    for (int i = 0; i <= GC.MaxGeneration; i++)
        //    {
        //        gcCollectionCounts.Add(GC.CollectionCount(i));
        //    }
        //    #region 执行方法
        //    for (int i = 0; i < iteration; i++)
        //    {
        //        QueryThreadCycleTime(hThread, ref start);//start
        //        action();
        //        QueryThreadCycleTime(hThread, ref end);//end
        //        second = (((decimal)end - (decimal)start) / (decimal)frequency);
        //        if (executeTimes.ContainsKey(second))
        //        {
        //            executeTimes[second] = executeTimes[second] + 1;
        //        }
        //        else
        //        {
        //            executeTimes.Add(second, 1);
        //        }
        //    }
        //    #endregion
        //    for (int i = 0; i <= GC.MaxGeneration; i++)
        //    {
        //        gcCollectionCounts[i] = GC.CollectionCount(i) - gcCollectionCounts[i];
        //    }
        //    return new CodeExecuteTime(executeTimes, gcCollectionCounts);
        //}
        public static CodeExecuteTime TimeByQueryPerformanceCounter(Action action, int iteration = 10000)
        {
            long frequency;
            if (!QueryPerformanceFrequency(out frequency))
            {
                throw new Win32Exception("硬件不支持“性能计数器”.");
            }

            iteration = (iteration <= 0 ? 1 : iteration);

            Dictionary<decimal, int> executeTimes = new Dictionary<decimal, int>();
            List<int> gcCollectionCounts = new List<int>();

            long start, end;
            decimal second;

            GC.Collect(GC.MaxGeneration);//强制 GC 进行收集，并记录目前各代已经收集的次数

            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                gcCollectionCounts.Add(GC.CollectionCount(i));
            }
            #region 执行方法
            for (int i = 0; i < iteration; i++)
            {
                QueryPerformanceCounter(out start);//start
                action();
                QueryPerformanceCounter(out end);//end
                second = (((decimal)end - (decimal)start) / (decimal)frequency);
                if (executeTimes.ContainsKey(second))
                {
                    executeTimes[second] = executeTimes[second] + 1;
                }
                else
                {
                    executeTimes.Add(second, 1);
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
