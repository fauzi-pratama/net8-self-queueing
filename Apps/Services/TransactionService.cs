
using Apps.Models;
using Newtonsoft.Json;

namespace Apps.Services
{
    public interface ITransactionService
    {
        string PublishTransaction(TransactionMessage transactionMessage);
        TransactionMessage? ReceiveTransaction();
        bool ProccessTransaction(TransactionMessage transactionMessage);
    }

    public class TransactionService(IQueueingService<TransactionMessage> queueingService, ILogger<TransactionService> logger)
        : ITransactionService
    {
        public string PublishTransaction(TransactionMessage transactionMessage)
        {
            queueingService.Enqueue(transactionMessage);

            return "Transaction Publish";
        }

        public TransactionMessage? ReceiveTransaction()
        {
            return queueingService.Dequeue();
        }

        public bool ProccessTransaction(TransactionMessage transactionMessage)
        {
            logger.LogInformation($"Success Receive Publish : {JsonConvert.SerializeObject(transactionMessage)}");

            return true;
        }
    }
}
