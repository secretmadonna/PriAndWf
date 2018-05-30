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
        [DllImport("kernel32.dll")]
        static extern bool QueryPerformanceFrequency(out long lpFrequency);
        [DllImport("kernel32.dll")]
        static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        static ILog staticLogger = LogManager.GetLogger("staticLogger");

        static long frequency;//3328123
        static void Main(string[] args)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

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
            var codeExecuteTime = CodeExecuteTimeHelper.Time(() => { for (int j = 0; j < 10000; j++) { } }, totalCount1);
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

            Console.ReadKey();
        }
    }
}
