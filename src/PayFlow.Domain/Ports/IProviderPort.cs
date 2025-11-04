using System.Threading.Tasks;

namespace PayFlow.Domain.Ports
{
    public class ProviderResult
    {
        public bool Success { get; set; }
        public string ExternalId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public interface IProviderPort
    {
        string Name { get; }
        Task<ProviderResult> ProcessPaymentAsync(decimal amount, string currency);
    }
}
