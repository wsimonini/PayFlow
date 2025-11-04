using PayFlow.Domain.Ports;
using PayFlow.Infrastructure.Providers.SecurePay.DTOs;
using System;
using System.Threading.Tasks;

namespace PayFlow.Infrastructure.Providers
{
    public class SecurePayAdapter : IProviderPort
    {
        public string Name => "SecurePay";

        public async Task<ProviderResult> ProcessPaymentAsync(decimal amount, string currency)
        {
            // 1?? Monta o payload no formato esperado pela SecurePay
            var request = new SecurePayRequestDto
            {
                AmountCents = (int)(amount * 100), // converte reais ? centavos
                CurrencyCode = currency,
                ClientReference = $"ORD-{DateTime.Now:yyyyMMddHHmmss}"
            };

            // 2?? Simula chamada HTTP à SecurePay
            await Task.Delay(100); // simula latência

            // 3?? Simula resposta do provedor
            var response = new SecurePayResponseDto
            {
                TransactionId = "SP-19283",
                Result = "success"
            };

            // 4?? Retorna resultado no formato do domínio
            return new ProviderResult
            {
                Success = response.Result == "success",
                ExternalId = response.TransactionId,
                Status = response.Result == "success" ? "approved" : "rejected"
            };
        }
    }
}
