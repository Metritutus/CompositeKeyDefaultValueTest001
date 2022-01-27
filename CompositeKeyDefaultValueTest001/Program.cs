using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace CompositeKeyDefaultValueTest001
{
    internal class Program
    {
        private static IHost Host { get; }

        static Program()
        {
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                                                        .ConfigureServices((hostBuilderContext, services) => ConfigureServices(services, hostBuilderContext.Configuration))
                                                        .Build();
        }

        static async Task Main(string[] args)
        {
            await Host.StartAsync().ConfigureAwait(false);

            await Host.StopAsync().ConfigureAwait(false);
            Host.Dispose();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExampleDbContext>();
            services.AddSingleton<Main>();
            services.AddHostedService<AppHostedService>();
        }
    }
}
