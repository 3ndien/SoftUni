namespace MortalEngines.Core
{
    using Contracts;
    using Common;
    using System.Collections.Generic;
    using MortalEngines.Entities.Contracts;
    using System.Linq;
    using MortalEngines.Entities;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
            IPilot pilot = new Pilot(name);
            this.pilots.Add(pilot);
            return string.Format(OutputMessages.PilotHired, pilot.Name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            IMachine tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);

            return string.Format(OutputMessages.TankManufactured, tank.Name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {

            if (this.machines.Any(m => m.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);
            string onOff = fighter.AggressiveMode ? "ON" : "OFF";

            return string.Format(OutputMessages.FighterManufactured, fighter.Name, fighter.AttackPoints, fighter.DefensePoints, onOff);
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            string result;
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null)
            {
                result = string.Format(OutputMessages.PilotNotFound, selectedPilotName);
                return result;
            }

            IMachine machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (machine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, selectedMachineName);
                return result;
            }

            if (machine.Pilot != null)
            {
                result = string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
                return result;
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            result = string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            return result;
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            string result = string.Empty;

            IMachine attackMachine = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);

            if (attackMachine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, attackingMachineName);
                return result;
            }

            IMachine defendingMachine = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (defendingMachine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, defendingMachineName);
                return result;
            }

            if (attackMachine.HealthPoints <= 0)
            {
                result = string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
                return result;
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                result = string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
                return result;
            }

            attackMachine.Attack(defendingMachine);

            result = string.Format(OutputMessages.AttackSuccessful, defendingMachine.Name, attackMachine.Name, defendingMachine.HealthPoints);
            return result;
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, pilotReporting);
            }

            string result = pilot.Report();
            return result;
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == machineName);

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, machineName);
            }

            string result = machine.ToString();

            return result;
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter fighter = this.machines.FirstOrDefault(f => f.Name == fighterName) as IFighter;

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            fighter.ToggleAggressiveMode();
            string result = string.Format(OutputMessages.FighterOperationSuccessful, fighterName);

            return result;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank tank = this.machines.FirstOrDefault(t => t.Name == tankName) as ITank;

            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            tank.ToggleDefenseMode();
            string result = string.Format(OutputMessages.TankOperationSuccessful, tankName);

            return result;
        }
    }
}