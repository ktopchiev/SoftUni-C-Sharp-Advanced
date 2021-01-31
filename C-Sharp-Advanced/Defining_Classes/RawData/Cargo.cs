namespace RawData
{
    public class Cargo
    {
        private int Weight { get; }
        public string Type { get; }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }
}