using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Calling(string number)
        {
            bool containLetters = IsContainLetters(number);

            if (!containLetters)
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        public void Dialing(string number)
        {
            bool containLetters = IsContainLetters(number);

            if (!containLetters)
            {
                Console.WriteLine($"Dialing... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        public bool IsContainLetters(string number)
        {
            if (number.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}
