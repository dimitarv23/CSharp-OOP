using Logger.Appenders;
using Logger.Appenders.Contracts;
using Logger.Layouts;
using Logger.Layouts.Contracts;
using Logger.Loggers;
using Logger.Loggers.Contracts;
using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            IFileWriter fw = new FileWriter("../../../Logs/");
            ILogFile file = new LogFile(fw);
            IFileAppender fileAppender = new FileAppender(simpleLayout, file);

            ILogger logger = new Logger.Loggers.Logger(consoleAppender, fileAppender);
            logger.Error("26/03/2020 2:08:11 PM", "Error parsing JSON.");
            logger.Info("26/03/2022 2:08:12 PM", "User Pesho successfully registered.");
        }
    }
}
