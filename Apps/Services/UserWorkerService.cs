
namespace Apps.Services
{
    public class UserWorkerService(IServiceScopeFactory factory) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await using AsyncServiceScope asyncScope = factory.CreateAsyncScope();
            var userService = asyncScope.ServiceProvider.GetRequiredService<IUserService>();

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);

                var dataUser = userService.ReceiveUser();

                if (dataUser is null) continue;

                userService.ProccessUser(dataUser);
            }
        }
    }
}
