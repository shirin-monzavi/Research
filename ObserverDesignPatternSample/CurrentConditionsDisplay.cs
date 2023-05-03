namespace ObserverDesignPatternSample
{
    public class CurrentConditionsDisplay : IObserver, IElementDisplay
    {
        private float temperature;
        private float humidity;
        private WeatherData weatherData;

        public CurrentConditionsDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Display()
        {
            Console.WriteLine("Current condition :" + temperature + " " + humidity);
        }

        public void Update(float temp, float humiditym, float pressure)
        {
            this.temperature = temp;
            this.humidity = humiditym;
            Display();
        }
    }
}
