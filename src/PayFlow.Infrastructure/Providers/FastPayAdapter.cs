using PayFlow.Domain.Ports;
using System.Threading.Tasks;

namespace PayFlow.Infrastructure.Providers
{
    public class FastPayAdapter : IProviderPort
    {
        public string Name => "FastPay";

        public async Task<ProviderResult> ProcessPaymentAsync(decimal amount, string currency)
        {
            // Simulação de envio para o provedor FastPay
            await Task.Delay(50); // Simula tempo de processamento

            return new ProviderResult
            {
                Success = true,
                ExternalId = "FP-884512",
                Status = "approved"
            };
        }
    }
}
