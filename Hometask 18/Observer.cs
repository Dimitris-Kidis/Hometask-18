using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public interface Observed
    {
        void AddObserver(Observer o);
        void RemoveObserver(Observer o);
        void NotifyObservers();
    }



    public interface Observer
    {
        void HandleEvent(int temp, int pressure);
    }



    public class MeteoStation : Observed
    {
        int temperature;
        int pressure;

        List<Observer> observers = new List<Observer>();

        public void setMeasurements(int t, int p)
        {
            temperature = t;
            pressure = p;
            NotifyObservers();
        }
        public void AddObserver(Observer o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(Observer o)
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


    public class FileObserver : Observer
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


    public class ConsoleObserver : Observer
    {
        public void HandleEvent(int temp, int pressure)
        {
            Console.WriteLine($"CONSOLE: Changes at {System.DateTime.Now.ToString()}. Temperature = {temp}, Pressure = {pressure}");
        }
    }
}
