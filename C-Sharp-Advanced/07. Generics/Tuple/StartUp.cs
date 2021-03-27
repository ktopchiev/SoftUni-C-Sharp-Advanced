using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Tuple<string, string, string> tuple1 = new Tuple<string, string, string>(input[0] + " " + input[1], input[2], input[3]);
            if (input.Length > 4)
            {
                tuple1 = new Tuple<string, string, string>(input[0] + " " + input[1], input[2],
                    input[3] + " " + input[4]);
            }
            Console.WriteLine(tuple1);

            input = Console.ReadLine().Split();
            Tuple<string, int, string> tuple2 = new Tuple<string, int, string>(input[0], int.Parse
            (input[1]), input[2] == "drunk" ? "True" : "False");
            Console.WriteLine(tuple2);

            input = Console.ReadLine().Split();
            Tuple<string, double, string> tuple3 = new Tuple<string, double, string>(input[0],
            double.Parse(input[1]), input[2]);
            if (input.Length > 3)
            {
                tuple3 = new Tuple<string, double, string>(input[0],
                    double.Parse(input[1]), input[2] + " " + input[3]);
            }
            Console.WriteLine(tuple3);
        }
    }
}