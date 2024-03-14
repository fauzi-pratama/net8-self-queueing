
using Apps.Models;

namespace Apps.Services
{
    public class TransactionWorkerService(IServiceScopeFactory factory) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await using AsyncServiceScope asyncScope = factory.CreateAsyncScope();
            var userService = asyncScope.ServiceProvider.GetRequiredService<ITransactionService>();

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);

                var dataUser = userService.ReceiveTransaction();

                if (dataUser is null) continue;

                userService.ProccessTransaction(dataUser);
            }
        }
    }
}
