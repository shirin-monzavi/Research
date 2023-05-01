using static StateDesignPattern.StockMarketContext.StockMarketState;

namespace StateDesignPattern
{
    public partial class StockMarketContext : IStockMarketState
    {
        private StockMarketState state;
        public StockMarketContext()
        {
            state = new CloseState(this);
        }

        public void EnqueueOrder()
        {
            state.EnqueueOrder();
        }

        private void enqueueOrder()
        {
            Console.WriteLine("The order has been enqueued");
        }

        private void preOrder()
        {
            Console.WriteLine("The order has been set");
        }

        public void CancellOrder()
        {
            state.CancellOrder();
        }

        private void cancellOrder()
        {
            Console.WriteLine("The order has been cancelled");
        }

        public void Close()
        {
            state.Close();
        }

        public void Open()
        {
            state.Open();
        }

        public void PreOpen()
        {
            state.PreOpen();
        }
    }
}
