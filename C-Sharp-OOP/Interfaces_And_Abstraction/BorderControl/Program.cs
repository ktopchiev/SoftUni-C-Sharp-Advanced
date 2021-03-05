using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            List<IBuyer> buyers = new List<IBuyer>();             

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] enteringIdentifiable = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (enteringIdentifiable.Length)
                {
                    case 4:
                        if (!buyers.Any(x => x.Name == enteringIdentifiable[0]))
                        {
                            buyers.Add(new Citizen(enteringIdentifiable[0],
                                enteringIdentifiable[2],
                                int.Parse(enteringIdentifiable[1]),
                                enteringIdentifiable[3]));
                        }
                        break;
                    case 3:
                        if (!buyers.Any(x => x.Name == enteringIdentifiable[0]))
                        {
                            buyers.Add(new Rebel(enteringIdentifiable[0],
                                int.Parse(enteringIdentifiable[1]),
                                enteringIdentifiable[2]));
                        }
                        break;
                    default:
                        break;
                }
            }


            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    //string birthYear = Console.ReadLine();

                    //city.Where(x => x.Birthdate.EndsWith(birthYear))
                    //    .Select(x => x.Birthdate)
                    //    .ToList()
                    //    .ForEach(Console.WriteLine);
                    Console.WriteLine(buyers.Sum(x => x.Food));
                    break;
                }


                foreach (var person in buyers.Where(p => p.Name == name))
                {
                    person.BuyFood();
                }
                //switch(enteringIdentifiable[0])
                //{
                //    case "Citizen":
                //        city.Add(new Citizen(enteringIdentifiable[1],
                //            enteringIdentifiable[3],
                //            int.Parse(enteringIdentifiable[2]),
                //            enteringIdentifiable[4]));
                //        break;
                //    case "Pet":
                //        city.Add(new Pet(enteringIdentifiable[1],
                //            enteringIdentifiable[2]));
                //        break;

                //}
            }
        }
    }
}
