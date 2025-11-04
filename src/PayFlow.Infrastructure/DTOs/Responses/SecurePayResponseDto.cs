namespace PayFlow.Infrastructure.Providers.SecurePay.DTOs
{
    public class SecurePayResponseDto
    {
        public string TransactionId { get; set; } = string.Empty;

        public string Result { get; set; } = string.Empty;
    }
}
