namespace StateDesignPattern
{
    public partial class StockMarketContext
    {
        public class StockMarketState : IStockMarketState
        {
            protected StockMarketContext context;

            public StockMarketState(StockMarketContext context)
            {
                this.context = context;
            }
            public virtual void Close()
            {
                throw new NotImplementedException();
            }

            public virtual void Open()
            {
                throw new NotImplementedException();
            }

            public virtual void PreOpen()
            {
                throw new NotImplementedException();
            }

            public virtual void EnqueueOrder()
            {
                throw new NotImplementedException();
            }

            public virtual void CancellOrder()
            {
                throw new NotImplementedException();
            }

            public class CloseState : StockMarketState
            {
                public CloseState(StockMarketContext context) : base(context)
                {
                }

                public override void Close()
                {
                    throw new Exception("Market Is Closed");
                }

                public override void PreOpen()
                {
                    context.state = new PreOpenState(context);
                }
            }

            public class OpenState : StockMarketState
            {
                public OpenState(StockMarketContext context) : base(context)
                {
                }

                public override void PreOpen()
                {
                    context.state = new PreOpenState(context);
                }

                public override void Open()
                {
                    Console.WriteLine("Market is opened");

                    context.enqueueOrder();
                }

                public override void EnqueueOrder()
                {
                    context.enqueueOrder();
                }

                public override void CancellOrder()
                {
                    context.cancellOrder();
                }
            }

            public class PreOpenState : StockMarketState
            {
                public PreOpenState(StockMarketContext context) : base(context)
                {
                }

                public override void Close()
                {
                    context.state = new CloseState(context);
                }

                public override void PreOpen()
                {
                    context.preOrder();
                }

                public override void Open()
                {
                    context.state = new OpenState(context);
                }

                public override void EnqueueOrder()
                {
                    context.preOrder();
                }

                public override void CancellOrder()
                {
                    context.cancellOrder();
                }
            }
        }
    }
}
