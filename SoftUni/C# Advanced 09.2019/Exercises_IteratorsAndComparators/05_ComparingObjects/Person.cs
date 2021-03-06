using System;

namespace _05_ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            else if (this.Age.CompareTo(other.Age) != 0)
            {
                return this.Age.CompareTo(other.Age);
            }
            else
            {
                return this.Town.CompareTo(other.Town);
            }
        }
    }
}
