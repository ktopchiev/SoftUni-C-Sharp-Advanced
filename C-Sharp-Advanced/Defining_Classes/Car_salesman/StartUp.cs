using System;
using System.Collections.Generic;

namespace Car_salesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Read engine number
            int n = int.Parse(Console.ReadLine());
            
            //Create list for storing all engines
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                //Initialize engines
                string[] engineInput =
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineInput[0];
                int power = int.Parse(engineInput[1]);

                int displacement = 0;
                string efficiency = null;

                Engine newEngine;
                
                //Get different inputs
                switch (engineInput.Length)
                {
                    case 4:
                        displacement = int.Parse(engineInput[2]);
                        efficiency = engineInput[3];
                        newEngine = new Engine(model, power, displacement, efficiency);
                        engines.Add(newEngine);
                        break;
                    case 3:
                        bool isNumeric = int.TryParse(engineInput[2], out displacement);
                        if (isNumeric)
                        {
                            newEngine = new Engine(model, power, displacement);
                        }
                        else
                        {
                            efficiency = engineInput[2];
                            newEngine = new Engine(model, power, efficiency);
                        }

                        engines.Add(newEngine);
                        break;
                    case 2:
                        newEngine = new Engine(model, power);
                        engines.Add(newEngine);
                        break;
                }
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                //A car's weight and color are optional
                string[] automobilesInput =
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = automobilesInput[0];
                string engineInput = automobilesInput[1];
                Engine engine = engines.Find(x => x.Model == engineInput);

                int weight = 0;
                string color = null;
                Car newCar;

                switch (automobilesInput.Length)
                {
                    case 4:
                        weight = int.Parse(automobilesInput[2]);
                        color = automobilesInput[3];
                        newCar = new Car(model, engine, weight, color);
                        cars.Add(newCar);
                        break;
                    case 3:
                        bool isNumeric = int.TryParse(automobilesInput[2], out weight);
                        if (isNumeric)
                        {
                            newCar = new Car(model, engine, weight);
                        }
                        else
                        {
                            color = automobilesInput[2];
                            newCar = new Car(model, engine, color);
                        }

                        cars.Add(newCar);
                        break;
                    case 2:
                        newCar = new Car(model, engine);
                        cars.Add(newCar);
                        break;
                }
            }
            
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}