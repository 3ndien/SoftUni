namespace P01_RawData
{
    public class Engine
    {
        private int speed;
        private int power;

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }

        public int Power { get => power; set => power = value; }
        public int Speed { get => speed; set => speed = value; }
    }
}
