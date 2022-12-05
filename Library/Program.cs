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

            var client = serviceProvider.GetRequiredService<Startup>();
            client.Start();
        }
    }
}