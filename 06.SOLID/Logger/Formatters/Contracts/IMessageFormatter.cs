using Logger.Layouts.Contracts;
using Logger.Messages.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Formatters.Contracts
{
    internal interface IMessageFormatter
    {
        ILayout Layout { get; }

        string FormatMessage(IMessage message);
    }
}
