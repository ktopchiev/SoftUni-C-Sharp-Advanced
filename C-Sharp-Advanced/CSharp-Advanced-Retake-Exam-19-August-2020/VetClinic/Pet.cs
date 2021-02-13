using System.Text;

namespace VetClinic
{
    public class Pet
    {
        public string Name { get;}
        public int Age { get;}
        public string Owner { get;}

        public Pet(string name, int age, string owner)
        {
            Name = name.Trim();
            Age = age;
            Owner = owner.Trim();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Name: {Name} ");
            sb.Append($"Age: {Age} ");
            sb.Append($"Owner: {Owner}");

            return sb.ToString().TrimEnd();
        }
    }
}