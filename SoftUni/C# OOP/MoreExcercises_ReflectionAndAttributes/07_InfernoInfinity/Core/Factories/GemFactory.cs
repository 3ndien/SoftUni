using _07_InfernoInfinity.Core.Factories.Contracts;
using _07_InfernoInfinity.Models;
using _07_InfernoInfinity.Models.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace _07_InfernoInfinity.Core.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem Create(string gemClarity, string gemType)
        {
            Clarity clarity = (Clarity)Enum.Parse(typeof(Clarity), gemClarity);

            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == gemType.ToLower());

            if (type == null)
            {
                throw new ArgumentException("Invalid gem type!");
            }

            IGem gem = (IGem)Activator.CreateInstance(type, new object[] { clarity });

            return gem;
        }
    }
}
