using log4net;
using log4net.Config;
using PriAndWf.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace PriAndWf.TestConApp
{
    class Program
    {
        static ILog staticLogger = LogManager.GetLogger("staticLogger");
        static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            Test3();

            Console.ReadKey();
        }

        [DllImport("kernel32.dll")]
        static extern bool QueryPerformanceFrequency(out long lpFrequency);
        [DllImport("kernel32.dll")]
        static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        public static void Test1()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            long frequency;//3328123
            if (QueryPerformanceFrequency(out frequency))
            {
                staticLogger.Info("start1");
                long start, end;
                int totalCount = 10000;
                Dictionary<decimal, int> dic = new Dictionary<decimal, int>();
                for (int i = 1; i <= totalCount; i++)
                {
                    QueryPerformanceCounter(out start);
                    //耗时代码
                    for (int j = 0; j < 10000; j++) { }
                    QueryPerformanceCounter(out end);
                    var s = (((decimal)end - (decimal)start) / (decimal)frequency);
                    if (dic.ContainsKey(s))
                    {
                        dic[s] = dic[s] + 1;
                    }
                    else
                    {
                        dic.Add(s, 1);
                    }
                }
                int totalCountLength = totalCount.ToString().Length;
                string str = string.Empty.PadLeft(totalCountLength, '0');
                var list = dic.OrderBy(m => m.Key).ToList();
                decimal su = 0;
                int c = totalCount;
                foreach (var item in list)
                {
                    staticLogger.Info(string.Format("耗时({0:" + str + "}/{1:" + str + "}) : {2} s", item.Value, totalCount, item.Key));
                    su += item.Key * item.Value;
                }
                if (list.Count >= 3)
                {
                    var first = list.First();
                    su -= first.Key * first.Value;
                    c -= first.Value;
                    var last = list.Last();
                    su -= last.Key * last.Value;
                    c -= last.Value;
                }
                var argR = su / c;
                staticLogger.Info(string.Format("平均耗时({0}/{1}) : {2} s", su, c, argR));
            }
            else
            {
                Console.WriteLine("硬件不支持“性能计数器”.");
            }
            Console.WriteLine("完成!");

            staticLogger.Info("start2");
            int totalCount1 = 10000;
            int totalCount1Length = totalCount1.ToString().Length;
            string str1 = string.Empty.PadLeft(totalCount1Length, '0');
            var codeExecuteTime = CodeExecuteTimeHelper.TimeByQueryPerformanceCounter(() => { for (int j = 0; j < 10000; j++) { } }, totalCount1);
            var list1 = codeExecuteTime.ExecuteTimes.OrderBy(m => m.Key).ToList();
            decimal su1 = 0;
            int c1 = totalCount1;
            foreach (var item in list1)
            {
                staticLogger.Info(string.Format("耗时({0:" + str1 + "}/{1:" + str1 + "}) : {2} s", item.Value, totalCount1, item.Key));
                su1 += item.Key * item.Value;
            }
            if (list1.Count >= 3)
            {
                var first = list1.First();
                su1 -= first.Key * first.Value;
                c1 -= first.Value;
                var last = list1.Last();
                su1 -= last.Key * last.Value;
                c1 -= last.Value;
            }
            var argR1 = su1 / c1;
            staticLogger.Info(string.Format("平均耗时({0}/{1}) : {2} s", su1, c1, argR1));
            for (int i = 0; i < codeExecuteTime.GcCollectionCounts.Count; i++)
            {
                Console.WriteLine(string.Format("Gen {0} : {1}", i, codeExecuteTime.GcCollectionCounts[i]));
            }
        }

        public static void Test2()
        {
            var count = 10;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(string.Format("平均耗时(TimeByGetTickCount) : {0}", CodeExecuteTimeHelper.TimeByGetTickCount(() => { testm(); }).GetExFirstLastAvg));
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(string.Format("平均耗时(TimeByGetThreadTimes) : {0}", CodeExecuteTimeHelper.TimeByGetThreadTimes(() => { testm(); }).GetExFirstLastAvg));
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(string.Format("平均耗时(TimeByQueryThreadCycleTime) : {0}", CodeExecuteTimeHelper.TimeByQueryThreadCycleTime(() => { testm(); }).GetExFirstLastAvg));
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(string.Format("平均耗时(TimeByQueryPerformanceCounter) : {0}", CodeExecuteTimeHelper.TimeByQueryPerformanceCounter(() => { testm(); }).GetExFirstLastAvg));
            }

            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < count; i++)
            {
                sw.Start();
                testm();
                sw.Stop();
                Console.WriteLine(string.Format("平均耗时(Stopwatch) : {0} ms", sw.ElapsedMilliseconds));
            }

            long s, e;
            for (int i = 0; i < count; i++)
            {
                s = DateTime.Now.Ticks;
                testm();
                e = DateTime.Now.Ticks;
                Console.WriteLine(string.Format("平均耗时(DateTime) : {0}", e - s));
            }
        }

        [DllImport("kernel32.dll")]
        static extern long GetTickCount();
        [DllImport("kernel32.dll")]
        static extern bool GetThreadTimes(IntPtr hThread, out long lpCreationTime, out long lpExitTime, out long lpKernelTime, out long lpUserTime);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentThread();
        [DllImport("kernel32.dll")]
        static extern bool QueryThreadCycleTime(IntPtr threadHandle, ref ulong cycleTime);
        public static void Test3()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            long tickCount;
            IntPtr hThread = GetCurrentThread();
            long lpCreationTime, lpExitTime, lpKernelTime, lpUserTime;
            ulong cycleTime = 0;
            long lpPerformanceCount;
            for (int i = 0; i < 1000; i++)
            {
                testm();

                tickCount = GetTickCount();
                logger.Info(string.Format("GetTickCount : {0}", tickCount));
                GetThreadTimes(hThread, out lpCreationTime, out lpExitTime, out lpKernelTime, out lpUserTime);
                logger.Info(string.Format("GetThreadTimes : {0}+{1}={2}", lpKernelTime, lpUserTime, lpKernelTime + lpUserTime));
                //QueryThreadCycleTime(hThread, ref cycleTime);
                //logger.Info(string.Format("QueryThreadCycleTime : {0}", cycleTime));
                //QueryPerformanceCounter(out lpPerformanceCount);
                //logger.Info(string.Format("QueryPerformanceCounter : {0}", lpPerformanceCount));
            }
            //   665/3328123=1.9981232664778314984151727565357e-4 s -> 0.2 ms
            //   666742/3328123=0.20033574480270110209268106978017 ms
            Console.WriteLine("完成！");
        }


        public static void testm()
        {
            for (int i = 0; i < 100000; i++) { }
        }
    }
}
