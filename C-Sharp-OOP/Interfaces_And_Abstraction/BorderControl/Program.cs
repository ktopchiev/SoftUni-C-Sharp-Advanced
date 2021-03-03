using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> city = new List<IIdentifiable>();

            while (true)
            {
                string[] enteringIdentifiable = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (enteringIdentifiable[0] == "End")
                {
                    string fakeId = Console.ReadLine();

                    city.Where(x => x.Id.EndsWith(fakeId))
                        .Select(x => x.Id)
                        .ToList()
                        .ForEach(Console.WriteLine);

                    break;
                }

                switch(enteringIdentifiable.Length)
                {
                    case 3:
                        city.Add(new Citizen(enteringIdentifiable[0], enteringIdentifiable[2], int.Parse(enteringIdentifiable[1])));
                        break;
                    case 2:
                        city.Add(new Robot(enteringIdentifiable[0], enteringIdentifiable[1]));
                        break;
                }
            }
        }
    }
}
