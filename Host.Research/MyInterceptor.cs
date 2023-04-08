using Castle.DynamicProxy;
using System.Reflection;

namespace HostSample
{
    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            if (invocation.ReturnValue.GetType() == typeof(Task<int>))
            {
                invocation.ReturnValue = ((Task)invocation.ReturnValue)
               .ContinueWith(task =>
               {
                   var res = ((Task<int>)task).Result + 1;

                   Console.WriteLine("DumpInterceptor Async return value is " + (invocation.ReturnValue ?? "NULL"));

                   return res;
               });
            }
            else if (invocation.Method.ReturnType == typeof(int))
            {
                invocation.ReturnValue = (int)invocation.ReturnValue + 1;

                Console.WriteLine("DumpInterceptor Sync return value is " + (invocation.ReturnValue ?? "NULL"));
            }
        }

        public static bool IsAsyncMethod(MethodInfo method)
        {
            return
                method.ReturnType == typeof(Task) ||
                method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>)
                ;
        }
    }
}