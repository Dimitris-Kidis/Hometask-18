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

        public void Eat()
        {
            FindFood();
            CheckFood();
            TryFood();
        }
        abstract public void FindFood();
        abstract public void CheckFood();
        abstract public void TryFood();
    }

    public interface IStrategy
    {
        void Feed();
    }

    class SmallAnimal : Animal, IStrategy
    {
        public SmallAnimal(string name) : base(name)
        {
        }

        public void Feed()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Feed {base.Name} with seeds");
            base.Eat();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void FindFood()
        {
            Console.WriteLine($"(1) {this.GetType().Name}: goes to find food in other place");
        }

        public override void CheckFood()
        {
            Console.WriteLine($"(2) {this.GetType().Name}: checks if there's any food");
        }

        public override void TryFood()
        {
            Console.WriteLine($"(3) {this.GetType().Name}: try what's next to it");
        }
    }

    class MediumAnimal : Animal, IStrategy
    {
        public MediumAnimal(string name) : base(name)
        {
        }

        public void Feed()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Feed {base.Name} with grass");
            base.Eat();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void FindFood()
        {
            Console.WriteLine($"(1) {this.GetType().Name}: finds food");
        }

        public override void CheckFood()
        {
            Console.WriteLine($"(2) {this.GetType().Name}: checks food");
        }

        public override void TryFood()
        {
            Console.WriteLine($"(3) {this.GetType().Name}: try food, but doesn't eat it");
        }
    }

    class LargeAnimal : Animal, IStrategy
    {
        public LargeAnimal(string name) : base(name)
        {
        }

        public void Feed()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Feed {base.Name} with meat");
            base.Eat();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void FindFood()
        {
            Console.WriteLine($"(1) {this.GetType().Name}: finds the most delicious food");
        }

        public override void CheckFood()
        {
            Console.WriteLine($"(2) {this.GetType().Name}: checks if there's more");
        }

        public override void TryFood()
        {
            Console.WriteLine($"(3) {this.GetType().Name}: try a piece of it");
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
            strategy.Feed();
        }
    }

}




// ------------------- Strategy without Template Method ------------------
/*
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


        public void setStrategy(IStrategy typeOfAnimal)
        {
            this.strategy = typeOfAnimal;
        }

        public void feedAnimal()
        {
            strategy.feed();
        }
    }

}
*/