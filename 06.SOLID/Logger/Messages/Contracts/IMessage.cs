using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Messages.Contracts
{
    public interface IMessage
    {
        string Date { get; }
        string MessageText { get; }
        ReportLevel Level { get; }
    }
}
