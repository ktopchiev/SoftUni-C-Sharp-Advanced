namespace RawData
{
    public class Engine
    {
        private int Speed { get; }
        public int Power { get; }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }
}