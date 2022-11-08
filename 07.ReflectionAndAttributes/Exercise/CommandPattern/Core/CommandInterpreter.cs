using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandArgs = args.Split();

            string cmdType = commandArgs[0];
            string[] arguments = commandArgs.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly()
                .GetTypes().FirstOrDefault(x => x.Name == cmdType + "Command");

            if (type == null)
            {
                throw new InvalidOperationException("Missing command");
            }

            Type commandInterface = type.GetInterface("ICommand");
            if (commandInterface == null)
            {
                throw new InvalidOperationException("Not a command");
            }

            var command = Activator.CreateInstance(type) as ICommand;

            string result = command.Execute(arguments);
            return result;
        }
    }
}
