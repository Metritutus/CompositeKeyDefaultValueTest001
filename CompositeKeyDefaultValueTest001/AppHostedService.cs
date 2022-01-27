using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace CompositeKeyDefaultValueTest001
{
    public class AppHostedService : IHostedService
    {
        private Main Main { get; }

        public AppHostedService(Main main)
        {
            Main = main;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Main.StartAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
