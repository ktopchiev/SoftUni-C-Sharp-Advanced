using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(200, 100);

            Console.WriteLine(sportCar.DefaultFuelConsumption); //10

            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(150, 50);

            Console.WriteLine(raceMotorcycle.DefaultFuelConsumption); //8
            Console.WriteLine(raceMotorcycle.Fuel);//50

            raceMotorcycle.Drive(10);

            Console.WriteLine(raceMotorcycle.Fuel);
        }
    }
}
