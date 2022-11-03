using Logger.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Logger.Loggers
{
    public class LogFile : ILogFile
    {
        private readonly StringBuilder sb;
        private readonly IFileWriter fileWriter;

        private LogFile()
        {
            sb = new StringBuilder();
        }
        public LogFile(IFileWriter fileWriter) : this()
        {
            this.fileWriter = fileWriter;
        }

        public int Size => this.Content.Length;

        public string Content => sb.ToString();

        public void SaveAs(string fileName)
        {
            this.fileWriter.Write(this.Content, fileName);
        }

        public void Write(string content)
        {
            this.sb.AppendLine(content);
        }
    }
}
