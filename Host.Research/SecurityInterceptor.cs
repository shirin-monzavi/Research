using Castle.DynamicProxy;

namespace HostSample
{
    public class SecurityInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var myIdentity = new MyIdentity();

            var findMethodName = myIdentity.MyRole.Where(m => m.Key == invocation.TargetType.Name + "." + invocation.Method.Name).FirstOrDefault();

            if (findMethodName.Value.Any())
            {
                var args = invocation.Arguments;
                var cast = (User)args.FirstOrDefault();

                var hasAccess = findMethodName.Value.Contains(cast.Claim);
                if (!hasAccess)
                {
                    throw new Exception("You do not have access");
                }

                invocation.Proceed();

                if (invocation.ReturnValue.GetType() == typeof(Task<int>))
                {
                    invocation.ReturnValue = ((Task)invocation.ReturnValue)
                        .ContinueWith(t =>
                        {
                            return ((Task<int>)t).Result + 1;
                        });

                }
                else if (invocation.Method.ReturnType == typeof(int))
                {
                    invocation.ReturnValue = (int)invocation.ReturnValue + 1;
                }
            }
        }
    }
}