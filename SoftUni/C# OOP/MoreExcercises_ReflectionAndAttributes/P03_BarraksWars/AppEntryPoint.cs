namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using P03_BarraksWars.Core.Commands;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IUnitFactory, UnitFactory>();
            serviceCollection.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
