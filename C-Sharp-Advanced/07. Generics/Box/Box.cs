using System.Text;

namespace Box
{
    public class Box<T>
    {
        private T box;

        public Box(T value)
        {
            this.box = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{box.GetType()}: ");
            sb.Append($"{box}");
            return sb.ToString();
        }
    }
}