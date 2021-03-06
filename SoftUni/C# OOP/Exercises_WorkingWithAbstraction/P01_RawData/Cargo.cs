namespace P01_RawData
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public string Type { get => type; set => type = value; }
        public int Weight { get => weight; set => weight = value; }
    }
}
