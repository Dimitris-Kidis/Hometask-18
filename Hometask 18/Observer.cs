using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public interface IObserved
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }



    public interface IObserver
    {
        void HandleEvent(int temp, int pressure);
    }



    public class MeteoStation : IObserved
    {
        int temperature;
        int pressure;

        List<IObserver> observers = new List<IObserver>();

        public void setMeasurements(int t, int p)
        {
            temperature = t;
            pressure = p;
            NotifyObservers();
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (var o in observers)
            {
                o.HandleEvent(temperature, pressure);
            }
        }
    }


    public class FileObserver : IObserver
    {
        public void HandleEvent(int temp, int pressure)
        {
            FileStream fileStream = File.Open("Temp&PressureInfo.txt",
                FileMode.Append, FileAccess.Write);

            StreamWriter fileWriter = new StreamWriter(fileStream);

            fileWriter.WriteLine($"FILE: Changes at {System.DateTime.Now.ToString()}. Temperature = {temp}, Pressure = {pressure}");
            fileWriter.Flush();
            fileWriter.Close();
            fileWriter.Dispose();
        }
    }


    public class ConsoleObserver : IObserver
    {
        public void HandleEvent(int temp, int pressure)
        {
            Console.Write($"CONSOLE: Changes at {System.DateTime.Now.ToString()}. ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"Temperature = {temp}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(", ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"Pressure = {pressure}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
