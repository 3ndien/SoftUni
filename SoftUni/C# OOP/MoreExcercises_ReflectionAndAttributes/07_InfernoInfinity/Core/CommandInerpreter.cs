using _07_InfernoInfinity.Core.Attributes;
using _07_InfernoInfinity.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace _07_InfernoInfinity.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider service;

        public CommandInterpreter(IServiceProvider service)
        {
            this.service = service;
        }

        public IExecutable InterpretCommand(string commandName, string[] commandData)
        {
            var classCommandName = (commandName + "Command");

            var assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == classCommandName.ToLower());

            if (type == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            FieldInfo[] fieldsToInject = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(a => a.AttributeType.Name == typeof(InjectAttribute).Name))
                .ToArray();

            object[] getFIelds = fieldsToInject.Select(f => service.GetService(f.FieldType)).ToArray();

            object[] ctorParams = new object[] { commandData }.Concat(getFIelds).ToArray();

            var commandInstance = (IExecutable)Activator.CreateInstance(type, ctorParams);

            return commandInstance;
        }
    }
}
