using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, Doctor> doctors = new Dictionary<string, Doctor>();
            Dictionary<string, Departament> departments = new Dictionary<string, Departament>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] inputData = command.Split();
                var departmentName = inputData[0];
                var firstName = inputData[1];
                var lastName = inputData[2];
                var patientName = inputData[3];
                var fullName = firstName + lastName;

                var patient = new Patient(patientName);

                if (!doctors.ContainsKey(fullName))
                {
                    doctors[fullName] = new Doctor(firstName, lastName);
                }
                if (!departments.ContainsKey(departmentName))
                {
                    departments[departmentName] = new Departament(departmentName);
                }

                if (departments[departmentName].IsFreeBed)
                {
                    var room = departments[departmentName].GetRoom();
                    room.Pacients.Add(patient);
                    doctors[fullName].AddPatient(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[args[0]].Rooms
                        .Where(r => r.Pacients.Count != 0)
                        .SelectMany(r => r.Pacients.Select(p => p.Name))));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[args[0]].Rooms[room - 1].Pacients.OrderBy(x => x.Name)));
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, doctors[args[0] + args[1]].Patients.OrderBy(x => x.Name)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
