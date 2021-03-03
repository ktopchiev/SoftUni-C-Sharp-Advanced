using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> city = new List<IBirthable>();

            while (true)
            {
                string[] enteringIdentifiable = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (enteringIdentifiable[0] == "End")
                {
                    string birthYear = Console.ReadLine();

                    city.Where(x => x.Birthdate.EndsWith(birthYear))
                        .Select(x => x.Birthdate)
                        .ToList()
                        .ForEach(Console.WriteLine);

                    break;
                }

                switch(enteringIdentifiable[0])
                {
                    case "Citizen":
                        city.Add(new Citizen(enteringIdentifiable[1],
                            enteringIdentifiable[3],
                            int.Parse(enteringIdentifiable[2]),
                            enteringIdentifiable[4]));
                        break;
                    case "Pet":
                        city.Add(new Pet(enteringIdentifiable[1],
                            enteringIdentifiable[2]));
                        break;
                }
            }
        }
    }
}
