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
        /// 获取起始时间至结束时间之间的一个随机时间
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
        public static readonly DateTime startDateTime = new DateTime(1970, 1, 1); // 计算时间戳的起始时间
        public static long ToTimestamp(DateTime? dt = null)
        {
            var endDateTime = dt ?? DateTime.Now; // 计算时间戳的截止时间
            var timeStamp = (long)(endDateTime - startDateTime).TotalMilliseconds; // 相差毫秒数
            return timeStamp;
        }
    }
}
