using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers.Contracts
{
    public interface IFileWriter
    {
        string FilePath { get; set; }

        void Write(string content, string fileName);
    }
}
