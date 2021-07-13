using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Departament
    {
        public Departament(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
            this.Capacity = 20;
            this.InitializeRooms();
        }

        public int Capacity { get; set; }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public bool IsFreeBed => this.Rooms.Any(r => r.Pacients.Count < 3);

        private void InitializeRooms()
        {
            for (int room = 0; room < 20; room++)
            {
                this.Rooms.Add(new Room());
            }
        }

        public Room GetRoom()
        {
            return this.Rooms.FirstOrDefault(r => r.Pacients.Count < 3);
        }
    }
}
