namespace PayFlow.Domain.Entities
{
    public class Payment
    {
        public string ExternalId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public decimal GrossAmount { get; set; }
        public decimal Fee { get; set; }
        public decimal NetAmount { get; set; }
        public string Currency { get; set; } = "BRL";
    }
}
