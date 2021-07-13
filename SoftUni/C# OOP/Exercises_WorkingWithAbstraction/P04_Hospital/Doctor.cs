using System.Collections.Generic;

namespace P04_Hospital
{
    public class Doctor
    {
        private List<Patient> patients;

        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.patients = new List<Patient>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Fullname => this.FirstName + this.LastName;

        public IReadOnlyCollection<Patient> Patients => this.patients.AsReadOnly();
    
        public void AddPatient(Patient patient)
        {
            this.patients.Add(patient);
        }
    }
}
