using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace P03_BarraksWars.Core.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var classCommandName = (commandName + "command").ToLower();

            var assembly = Assembly.GetExecutingAssembly();

            var commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == classCommandName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command name!");
            }

            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInject.Select(f => serviceProvider.GetService(f.FieldType)).ToArray();

            object[] ctorArgs = new object[] { data }.Concat(injectArgs).ToArray();

            var commandInstance = (IExecutable)Activator.CreateInstance(commandType, ctorArgs);


            return commandInstance;
        }
    }
}
