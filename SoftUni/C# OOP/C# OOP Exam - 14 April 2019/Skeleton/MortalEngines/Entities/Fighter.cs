namespace MortalEngines.Entities
{
    using Contracts;
    using System.Text;

    public class Fighter : BaseMachine, IFighter
    {
        private const double DefaultHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, DefaultHealthPoints)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            switch (this.AggressiveMode)
            {
                case false:
                    this.AggressiveMode = true;
                    this.AttackPoints += 50;
                    this.DefensePoints -= 25;
                    break;
                case true:
                    this.AggressiveMode = false;
                    this.AttackPoints -= 50;
                    this.DefensePoints += 25;
                    break;
            }
        }

        public override string ToString()
        {
            string onOff = this.AggressiveMode ? "ON" : "OFF";
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Aggressive: {onOff}");

            return sb.ToString().TrimEnd();
        }
    }
}
