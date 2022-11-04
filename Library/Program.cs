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
            services.SetRepositories();
            services.SetServices();
            services.SetPages();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            Client client = serviceProvider.GetRequiredService<Client>();
            client.Start();
        }
    }
}