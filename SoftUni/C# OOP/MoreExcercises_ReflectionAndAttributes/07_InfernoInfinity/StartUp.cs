using _07_InfernoInfinity.Core;
using _07_InfernoInfinity.Core.Contracts;
using _07_InfernoInfinity.Core.Data;
using _07_InfernoInfinity.Core.Data.Contracts;
using _07_InfernoInfinity.Core.Factories;
using _07_InfernoInfinity.Core.Factories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace _P07_InfernoInfinity
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = GetServiceProvider();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            var engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static ServiceProvider GetServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IWeaponRepository, WeaponRepository>();
            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();

            return services.BuildServiceProvider();
        }
    }
}
