using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers.Contracts
{
    public interface ILogFile
    {
        int Size { get; }
        string Content { get; }

        void Write(string content);
        void SaveAs(string fileName);
    }
}
