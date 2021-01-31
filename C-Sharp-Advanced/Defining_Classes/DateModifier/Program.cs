using System;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDateInput = Console.ReadLine();

            string secondDateInput = Console.ReadLine();

            DateModifier myModifier = new DateModifier(firstDateInput, secondDateInput);

            Console.WriteLine(myModifier.GetDaysDifference());
        }
    }
}