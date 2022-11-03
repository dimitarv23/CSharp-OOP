using Logger.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Loggers
{
    public class FileWriter : IFileWriter
    {
        public FileWriter(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }

        public void Write(string content, string fileName)
        {
            string outputPath = Path.Combine(this.FilePath, fileName);
            File.WriteAllText(outputPath, content);
        }
    }
}
