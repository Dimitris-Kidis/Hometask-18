using System;



// 1. Observer pattern ✅
// 2. Strategy + Template Method ✅

namespace App
{
    class Program
    {
        public static void Main(string[] args)
        {
            // 1.
            MeteoStation station = new MeteoStation();
            station.AddObserver(new ConsoleObserver());
            station.AddObserver(new FileObserver());

            station.setMeasurements(new Random().Next(20, 35), new Random().Next(745, 770));
            Console.WriteLine();

            // 2.
            Context context = new();
            int animalType = new Random().Next(3);
            IStrategy animal;
            switch(animalType)
            {
                case 0:
                    animal = new SmallAnimal("George");
                    break;
                case 1:
                    animal = new MediumAnimal("Sia");
                    break;
                case 2:
                    animal = new LargeAnimal("Joe");
                    break;
                default: throw new Exception("There's no such an animal!");

            }
            context.setStrategy(animal);
            context.feedAnimal();

        }
    }
}