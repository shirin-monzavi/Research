using ObserverDesignPatternSample;

class Program
{
    public static void Main(string[] arg)
    {
        var weatherData = new WeatherData();

        var currentDisplay = new CurrentConditionsDisplay(weatherData);

        weatherData.SetMeasurement(10f, 20f, 30f);
       

    }
}