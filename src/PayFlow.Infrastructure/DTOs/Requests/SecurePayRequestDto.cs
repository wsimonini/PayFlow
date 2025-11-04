namespace PayFlow.Infrastructure.Providers.SecurePay.DTOs
{
    public class SecurePayRequestDto
    {
        public int AmountCents { get; set; }

        public string CurrencyCode { get; set; } = string.Empty;

        public string ClientReference { get; set; } = string.Empty;
    }
}
