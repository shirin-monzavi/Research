namespace ObserverDesignPatternSample
{
    public interface IObserver
    {
        public void Update(float temp, float humiditym, float pressure);
    }
}