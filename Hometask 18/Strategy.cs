using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    abstract class Animal
    {
        public string Name { get; }

        public Animal(string name)
        {
            Name = name;
        }
    }

    public interface IStrategy
    {
        void feed();
    }

    class SmallAnimal : Animal, IStrategy
    {
        public SmallAnimal(string name) : base(name)
        {
        }

        public void feed()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Feed {base.Name} with seeds");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class MediumAnimal : Animal, IStrategy
    {
        public MediumAnimal(string name) : base(name)
        {
        }

        public void feed()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Feed {base.Name} with grass");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class LargeAnimal : Animal, IStrategy
    {
        public LargeAnimal(string name) : base(name)
        {
        }

        public void feed()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Feed {base.Name} with meat");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class Context
    {
        IStrategy strategy;


        public void setStrategy (IStrategy typeOfAnimal)
        {
            this.strategy = typeOfAnimal;
        }

        public void feedAnimal ()
        {
            strategy.feed();
        }
    }

}
