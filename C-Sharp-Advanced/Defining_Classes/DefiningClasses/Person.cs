namespace DefiningClasses
{
    public class Person
    {
        //private string name;
        //private int age;

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age)
        : this()
        {
            Age = age;
        }

        public Person(int age, string name)
        : this(age)
        {
            Age = age;
            Name = name;
        }
        
        public string Name { get; set; }
        public int Age  { get; set; }
    }
}