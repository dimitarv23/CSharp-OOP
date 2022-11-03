using Logger.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders.Contracts
{
    public interface IFileAppender : IAppender
    {
        ILogFile LogFile { get; }

        void SaveLogFile(string fileName);
    }
}
