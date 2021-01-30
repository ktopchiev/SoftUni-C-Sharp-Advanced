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

        public List<Person> GetOlderThanThirtyMembers()
        {
            List<Person> adultMembers = new List<Person>();

            foreach (var familyMember in People)
            {
                if (familyMember.Age > 30)
                {
                    adultMembers.Add(familyMember);
                }
            }
            
            return adultMembers;
        }
    }
}