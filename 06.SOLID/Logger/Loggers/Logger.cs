using Logger.Appenders;
using Logger.Appenders.Contracts;
using Logger.Common;
using Logger.Enums;
using Logger.Loggers.Contracts;
using Logger.Messages;
using Logger.Messages.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers
{
    public class Logger : ILogger, IAppenderCollection
    {
        private readonly ICollection<IAppender> appenders;

        private Logger()
        {
            this.appenders = new List<IAppender>();
        }
        public Logger(params IAppender[] appenders) : this()
        {
            this.appenders.AddRange(appenders);
        }

        public IReadOnlyCollection<IAppender> Appenders => this.appenders.AsReadOnly();

        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

        public bool RemoveAppender(IAppender appender)
        {
            return this.appenders.Remove(appender);
        }

        public void Clear()
        {
            this.appenders.Clear();
        }

        public void Info(string date, string message)
        {
            LogMessage(date, message, ReportLevel.Info);
        }

        public void Warning(string date, string message)
        {
            LogMessage(date, message, ReportLevel.Warning);
        }

        public void Error(string date, string message)
        {
            LogMessage(date, message, ReportLevel.Error);
        }

        public void Critical(string date, string message)
        {
            LogMessage(date, message, ReportLevel.Critical);
        }

        public void Fatal(string date, string message)
        {
            LogMessage(date, message, ReportLevel.Fatal);
        }

        private void LogMessage(string date, string messageText, ReportLevel level)
        {
            IMessage message = new Message(date, messageText, level);

            foreach (var appender in this.appenders)
            {
                appender.Append(message);
            }
        }
    }
}
