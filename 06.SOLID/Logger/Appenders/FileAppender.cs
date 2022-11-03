using Logger.Appenders.Contracts;
using Logger.Formatters;
using Logger.Formatters.Contracts;
using Logger.Layouts.Contracts;
using Logger.Loggers.Contracts;
using Logger.Messages.Contracts;
using System;

namespace Logger.Appenders
{
    public class FileAppender : IFileAppender
    {
        private readonly IMessageFormatter formatter;

        private FileAppender()
        {
            Count = 0;
        }
        public FileAppender(ILayout layout, ILogFile logFile) : this()
        {
            Layout = layout;
            LogFile = logFile;
            formatter = new MessageFormatter(Layout);
        }

        public int Count { get; private set; }

        public ILayout Layout { get; }

        public ILogFile LogFile { get; }

        public void Append(IMessage message)
        {
            var formattedMessage = formatter.FormatMessage(message);

            LogFile.Write(formattedMessage);
        }

        public void SaveLogFile(string fileName)
        {
            LogFile.SaveAs(fileName);
        }
    }
}
