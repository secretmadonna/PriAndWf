using System;

namespace PriAndWf.Infrastructure.Log
{
    public class NullLogger : ILogger
    {
        /// <summary>
        /// Gets the default <see cref="NullLogger"/> instance.
        /// </summary>
        public static NullLogger Instance { get; } = new NullLogger();

        public void Warn(string str, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
