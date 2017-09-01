using System;

namespace PriAndWf.Infrastructure.Log
{
    public interface ILogger
    {
        void Warn(string str, Exception ex);
    }
}
