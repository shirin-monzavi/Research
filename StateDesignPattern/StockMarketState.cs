namespace StateDesignPattern
{
    public interface IStockMarketState
    {
        void Close();
        void Open();
        void PreOpen();
    }
}
