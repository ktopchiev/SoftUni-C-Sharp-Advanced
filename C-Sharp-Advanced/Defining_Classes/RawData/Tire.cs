namespace RawData
{
    public class Tire
    {
        public double Pressure { get; }
        private int Age { get; }

        public Tire(double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }
    }
}