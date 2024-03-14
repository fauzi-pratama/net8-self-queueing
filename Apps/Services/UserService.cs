
using Apps.Models;
using Newtonsoft.Json;

namespace Apps.Services
{
    public interface IUserService
    {
        string PublishUser(UserMessage userMessage);
        UserMessage? ReceiveUser();
        bool ProccessUser(UserMessage userMessage);
    }

    public class UserService(IQueueingService<UserMessage> queueingService, ILogger<UserService> logger) 
        : IUserService
    {
        public string PublishUser(UserMessage userMessage)
        {
            queueingService.Enqueue(userMessage);

            return "User created";
        }

        public UserMessage? ReceiveUser()
        {
            return queueingService.Dequeue();
        }

        public bool ProccessUser(UserMessage userMessage)
        {
            logger.LogInformation($"Success Receive User : {JsonConvert.SerializeObject(userMessage)}");

            return true;
        }
    }
}
