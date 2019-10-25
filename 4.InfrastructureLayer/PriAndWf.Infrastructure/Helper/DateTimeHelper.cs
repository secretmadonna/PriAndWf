using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriAndWf.Infrastructure.Helper
{
    public class DateTimeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns></returns>
        public static DateTime GetRandomTime(DateTime startTime, DateTime endTime)
        {
            var ts = endTime - startTime;
            var totalSeconds = ts.TotalSeconds;
            if (totalSeconds <= 0)
            {
                var eMsg = $"参数错误，{nameof(endTime)}必须大于{nameof(startTime)}";
                throw new ArgumentException(eMsg);
            }
            var r = new Random();
            var dt = startTime.AddSeconds(r.NextDouble() * totalSeconds);
            return dt;
        }
    }
}
