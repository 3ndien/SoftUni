namespace P04_Hospital
{
    public class Patient
    {
        public Patient(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public Departament Department { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
