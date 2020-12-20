using Ninject;
using Ninject.Parameters;

namespace BLL.ServiceModules
{
    public class IoC
    {
        private static IKernel Kernel = new StandardKernel(new ServiceModule());

        public static T Get<T>(params IParameter[] parameters)
        {
            return Kernel.Get<T>(parameters);
        }
    }
}
