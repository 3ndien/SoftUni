using System.Collections.Generic;

namespace P04_Hospital
{
    public class Room
    {
        public Room()
        {
            this.Pacients = new List<Patient>();
        }

        public int Capacity => 3;

        public List<Patient> Pacients { get; set; }
    }
}