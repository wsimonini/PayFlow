using PayFlow.Domain.Entities;
using PayFlow.Domain.Ports;
using PayFlow.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayFlow.Application.UseCases
{
    public class ProcessPaymentUseCase
    {
        private readonly IEnumerable<IProviderPort> _providers;
        private readonly FastPayFeeCalculator _fastPayFee;
        private readonly SecurePayFeeCalculator _securePayFee;

        public ProcessPaymentUseCase(IEnumerable<IProviderPort> providers, FastPayFeeCalculator fastFee, SecurePayFeeCalculator secureFee)
        {
            _providers = providers;
            _fastPayFee = fastFee;
            _securePayFee = secureFee;
        }

        public async Task<Payment> ExecuteAsync(decimal amount, string currency)
        {
            var preferred = SelectProviderByAmount(amount);
            var result = await preferred.ProcessPaymentAsync(amount, currency);
            if (!result.Success)
                preferred = _providers.First(p => p.Name != preferred.Name);

            var (fee, net) = preferred.Name == "FastPay" ? _fastPayFee.Calculate(amount) : _securePayFee.Calculate(amount);

            return new Payment
            {
                ExternalId = result.ExternalId,
                Status = result.Status,
                Provider = preferred.Name,
                GrossAmount = amount,
                Fee = fee,
                NetAmount = net
            };
        }

        private IProviderPort SelectProviderByAmount(decimal amount) =>
            amount < 100m ? _providers.First(p => p.Name == "FastPay") : _providers.First(p => p.Name == "SecurePay");
    }
}
