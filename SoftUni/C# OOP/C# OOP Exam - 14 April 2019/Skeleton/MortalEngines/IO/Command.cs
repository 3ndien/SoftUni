
namespace MortalEngines.IO
{
    using Contracts;
    using Core.Contracts;
    using System;

    public class Command : ICommand
    {
        private IMachinesManager machinesManager;

        public Command(IMachinesManager machinesManager, string commandName, params string[] data)
        {
            this.Name = commandName;
            this.Data = data;
            this.machinesManager = machinesManager;
        }

        public string Name { get; private set; }

        public string[] Data { get; private set; }

        public string Execute()
        {
            switch (this.Name)
            {
                case "HirePilot":
                    return machinesManager.HirePilot(this.Data[0]);
                case "ManufactureTank":
                    return machinesManager.ManufactureTank(this.Data[0], double.Parse(this.Data[1]), double.Parse(this.Data[2]));
                case "ManufactureFighter":
                    return machinesManager.ManufactureFighter(this.Data[0], double.Parse(this.Data[1]), double.Parse(this.Data[2]));
                case "Engage":
                    return machinesManager.EngageMachine(this.Data[0], this.Data[1]);
                case "Attack":
                    return machinesManager.AttackMachines(this.Data[0], this.Data[1]);
                case "PilotReport":
                    return machinesManager.PilotReport(this.Data[0]);
                case "MachineReport":
                    return machinesManager.MachineReport(this.Data[0]);
                case "AggressiveMode":
                    return machinesManager.ToggleFighterAggressiveMode(this.Data[0]);
                case "DefenseMode":
                    return machinesManager.ToggleTankDefenseMode(this.Data[0]);
                default:
                    throw new Exception();
            }
        }
    }
}
