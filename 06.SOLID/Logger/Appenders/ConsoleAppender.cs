using Logger.Appenders.Contracts;
using Logger.Formatters;
using Logger.Formatters.Contracts;
using Logger.Layouts.Contracts;
using Logger.Messages.Contracts;
using System;

namespace Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private readonly IMessageFormatter messageFormatter;

        private ConsoleAppender()
        {
            this.Count = 0;
        }
        public ConsoleAppender(ILayout layout) : this()
        {
            this.Layout = layout;
            this.messageFormatter = new MessageFormatter(this.Layout);
        }

        public int Count { get; private set; }

        public ILayout Layout { get; }

        public void Append(IMessage message)
        {
            var formattedMessage = this.messageFormatter.FormatMessage(message);

            Console.WriteLine(formattedMessage);
            this.Count++;
        }
    }
}
