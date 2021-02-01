using System.Collections.Generic;
using System.Text;

namespace Car_salesman
{
    public class Car
    {
        public string Model { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public Engine Engine { get; set; }
        
        public Car(){}
        
        public Car(string model, Engine engine)
        :this()
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
        :this(model, engine)
        {
            Weight = weight;
        }
        
        public Car(string model, Engine engine, string color)
        :this(model, engine)
        {
            Color = color;
        }
        
        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            Color = color;
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int displacement = Engine.Displacement;
            string efficiency = Engine.Efficiency;
                
            sb.Append($"{Model}:\n");
            sb.Append($"  {Engine.Model}:\n");
            sb.Append($"    Power: {Engine.Power}\n");
            if (displacement != 0 && efficiency != null)
            {
                sb.Append($"    Displacement: {displacement}\n");
                sb.Append($"    Efficiency: {efficiency}\n");
            }
            else if (displacement != 0 && efficiency == null)
            {
                sb.Append($"    Displacement: {displacement}\n");
                sb.Append("    Efficiency: n/a\n");
            }
            else if (displacement == 0 && efficiency != null)
            {
                sb.Append("    Displacement: n/a\n");
                sb.Append($"    Efficiency: {efficiency}\n");
            }
            else if (displacement == 0 && efficiency == null)
            {
                sb.Append("    Displacement: n/a\n");
                sb.Append("    Efficiency: n/a\n");
            }

            if (Weight != 0 && Color != null)
            {
                sb.Append($"  Weight: {Weight}\n");
                sb.Append($"  Color: {Color}");
            }
            else if (Weight != 0 && Color == null)
            {
                sb.Append($"  Weight: {Weight}\n");
                sb.Append("  Color: n/a");
            }
            else if (Weight == 0 && Color != null)
            {
                sb.Append("  Weight: n/a\n");
                sb.Append($"  Color: {Color}");
            }
            else if (Weight == 0 && Color == null)
            {
                sb.Append("  Weight: n/a\n");
                sb.Append("  Color: n/a");
            }
            
            return sb.ToString();
        }
    }
}