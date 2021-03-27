using System;

namespace VehiclesExtension //Extension
{
    public class Program
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));


            var truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            var busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));


            //Get number of commands
            int n = int.Parse(Console.ReadLine());

            //Action
            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Action(commands, car, truck, bus);
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        public static void Action(string[] commands, Car car, Truck truck, Bus bus)
        {
            if (commands.Length > 1)
            {
                switch (commands[1])
                {
                    case "Car":
                        if (commands[0] == "Drive")
                        {
                            Console.WriteLine(car.Drive(double.Parse(commands[2])));
                        }
                        else if (commands[0] == "Refuel")
                        {
                            car.Refuel(double.Parse(commands[2]));
                        }
                        break;
                    case "Truck":
                        if (commands[0] == "Drive")
                        {
                            Console.WriteLine(truck.Drive(double.Parse(commands[2])));
                        }
                        else if (commands[0] == "Refuel")
                        {
                            truck.Refuel(double.Parse(commands[2]));
                        }
                        break;
                    case "Bus":
                        if (commands[0] == "Drive")
                        {
                            Console.WriteLine(bus.DriveFull(double.Parse(commands[2])));
                        }
                        else if (commands[0] == "Refuel")
                        {
                            bus.Refuel(double.Parse(commands[2]));
                        }
                        else if (commands[0] == "DriveEmpty")
                        {
                            Console.WriteLine(bus.Drive(double.Parse(commands[2])));
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
