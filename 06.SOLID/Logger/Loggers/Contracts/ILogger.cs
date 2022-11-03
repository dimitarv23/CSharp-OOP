using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers.Contracts
{
    public interface ILogger
    {
        public void Info(string date, string message);
        public void Warning(string date, string message);
        public void Error(string date, string message);
        public void Critical(string date, string message);
        public void Fatal(string date, string message);
    }
}
