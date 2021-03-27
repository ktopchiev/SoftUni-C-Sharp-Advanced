namespace Tuple
{
    public class Tuple<T1,T2,T3>
    {
        public object Key { get; set; }
        public object Value { get; set; }
        
        public object Value2 { get; set; }

        public Tuple(T1 key, T2 value, T3 value2)
        {
            Key = key;
            Value = value;
            Value2 = value2;
        }
        
        

        public override string ToString()
        {
            return $"{Key} -> {Value} -> {Value2}";
        }
    }
}