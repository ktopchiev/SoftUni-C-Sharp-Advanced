using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string animalType = Console.ReadLine();
                string[] animalData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (animalType == "Beast!")
                {
                    foreach (var animal in animals)
                    {
                        var animalTypeOutput = animal.GetType().ToString().Split('.').Last();
                        Console.WriteLine(animalTypeOutput);
                        Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                        animal.ProduceSound();
                    }

                    break;
                }

                string name = animalData[0];
                int age = int.Parse(animalData[1]);
                string gender = animalData[2];

                if (age >= 0 && name != null && gender != null)
                {
                    switch (animalType)
                    {
                        case "Cat":
                            Cat newCat = new Cat(name, age, gender);
                            animals.Add(newCat);
                            break;
                        case "Dog":
                            Dog newDog = new Dog(name, age, gender);
                            animals.Add(newDog);
                            break;
                        case "Frog":
                            Frog newFrog = new Frog(name, age, gender);
                            animals.Add(newFrog);
                            break;
                        case "Kitten":
                            Kitten newKitten = new Kitten(name, age);
                            animals.Add(newKitten);
                            break;
                        case "Tomcat":
                            Tomcat newTomcat = new Tomcat(name, age);
                            animals.Add(newTomcat);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
