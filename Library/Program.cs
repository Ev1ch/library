using Microsoft.Extensions.DependencyInjection;

using DAL;
using BAL;
using PL;

namespace Library
{
    public class Program
    {
       public static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            services.SetDalDependencies();
            services.SetBllDependencies();
            services.SetPlDependencies();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            Frontend client = serviceProvider.GetRequiredService<Frontend>();
            client.Start();
        }
    }
}