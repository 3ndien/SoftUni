namespace MortalEngines.Entities
{
    using Contracts;
    using System.Text;

    public class Tank : BaseMachine, ITank
    {
        private const double DefaultHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, DefaultHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            switch (this.DefenseMode)
            {
                case false:
                    this.DefenseMode = true;
                    this.AttackPoints -= 40;
                    this.DefensePoints += 30;
                    break;
                case true:
                    this.DefenseMode = false;
                    this.AttackPoints += 40;
                    this.DefensePoints -= 30;
                    break;
                
            }
        }

        public override string ToString()
        {
            string onOff = this.DefenseMode ? "ON" : "OFF";
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Defense: {onOff}");

            return sb.ToString().TrimEnd();
        }
    }
}
