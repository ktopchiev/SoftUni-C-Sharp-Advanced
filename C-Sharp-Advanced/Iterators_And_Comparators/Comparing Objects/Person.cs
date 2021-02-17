using System;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        private string Name { get; }

        private int Age { get; }

        private string Town { get; }

        public int CompareTo(Person other)
        {
            if (Name != other.Name)
            {
                return Name.CompareTo(other.Name);
            }

            if (Age != other.Age)
            {
                return Age.CompareTo(other.Age);
            }

            return Town != other.Town ? Town.CompareTo(other.Town) : 0;
        }
    }
}