namespace CircuitBreakerSample
{
    public class CircuitBreaker
    {
        CircuitBreakerState state;
        public CircuitBreaker()
        {
            state = new CircuitBreakerClosed(this);
        }

        public async Task ExecuteService<T>(Func<Task<T>> func)
        {
            await state.ExecuteService(func);
        }

        private abstract class CircuitBreakerState
        {
            protected CircuitBreaker circuitBreaker;

            protected CircuitBreakerState(CircuitBreaker circuitBreaker)
            {
                this.circuitBreaker = circuitBreaker;
            }

            public abstract Task ExecuteService<T>(Func<Task<T>> func);
        }
        private class CircuitBreakerClosed : CircuitBreakerState
        {
            private int _errorCount;
            public CircuitBreakerClosed(CircuitBreaker circuitBreaker) : base(circuitBreaker)
            {
                _errorCount = 0;
            }

            public override async Task ExecuteService<T>(Func<Task<T>> func)
            {
                try
                {
                    await func();
                }
                catch (Exception exception)
                {
                    _trackError(exception);
                }
            }

            private void _trackError(Exception exception)
            {
                _errorCount++;
                if (_errorCount >= Config.CircuitClosedErrorLimit)
                {
                    circuitBreaker.state = new CircuitBreakerOpened(circuitBreaker);
                }
            }
        }
        private class CircuitBreakerOpened : CircuitBreakerState
        {
            public CircuitBreakerOpened(CircuitBreaker circuitBreaker) : base(circuitBreaker)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    circuitBreaker.state = new CircuitBreakerHalfOpened(circuitBreaker);
                });

            }

            public override Task ExecuteService<T>(Func<Task<T>> func)
            {
                throw new NotImplementedException();
            }
        }

        private class CircuitBreakerHalfOpened : CircuitBreakerState
        {
            private int successCount = 0;
            public CircuitBreakerHalfOpened(CircuitBreaker circuitBreaker) : base(circuitBreaker)
            {
            }

            public override async Task ExecuteService<T>(Func<Task<T>> func)
            {
                try
                {
                    var result = await func();
                    successCount++;
                    if (successCount >= Config.CircuitHalfOpenSuccessLimit)
                    {
                        circuitBreaker.state = new CircuitBreakerClosed(circuitBreaker);
                    }

                }
                catch (Exception)
                {
                    circuitBreaker.state = new CircuitBreakerOpened(circuitBreaker);
                    throw;
                }
            }
        }
    }
}
