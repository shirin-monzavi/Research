using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPatternSample
{
    public class WeatherData : ISubject
    {
        private List<IObserver> observers;
        private float temperature;
        private float humidity;
        private float pressure;
        public WeatherData()
        {
            observers = new List<IObserver>();
        }
        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(temperature, humidity, pressure);   
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void MeasurmentsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurement(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature; 
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurmentsChanged();
        }
    }
}
