namespace Apps.Models
{
    public class TransactionMessage
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime Date { get; set; }
    }
}
