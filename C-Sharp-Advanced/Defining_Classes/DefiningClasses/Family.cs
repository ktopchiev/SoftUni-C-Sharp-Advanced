using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> People { get; set; }

        public Family()
        {
            People = new List<Person>();
        }
        
        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestPerson = People.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPerson;
        }
    }
}