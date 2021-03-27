using System;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            ICallable stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                if (number.Length == 7)
                {
                    stationaryPhone.Dialing(number);
                }
                else if (number.Length == 10)
                {
                    stationaryPhone.Calling(number);
                }
                else
                {
                    Console.WriteLine("Invalid number");
                }
            }

            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IBrowsable smartphone = new Smartphone();

            foreach (var url in urls)
            {
                
                smartphone.Browsing(url);
                
            }
        }
    }
}
