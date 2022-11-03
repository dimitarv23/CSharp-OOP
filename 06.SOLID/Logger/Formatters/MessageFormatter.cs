using Logger.Formatters.Contracts;
using Logger.Layouts.Contracts;
using Logger.Messages.Contracts;
using System;

namespace Logger.Formatters
{
    internal class MessageFormatter : IMessageFormatter
    {
        public MessageFormatter(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public string FormatMessage(IMessage message)
        {
            return string.Format(this.Layout.Format, message.Date, message.Level.ToString(), message.MessageText);
        }
    }
}
