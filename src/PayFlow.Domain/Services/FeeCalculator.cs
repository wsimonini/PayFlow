using System;

namespace PayFlow.Domain.Services
{
    public class FastPayFeeCalculator
    {
        public (decimal Fee, decimal Net) Calculate(decimal amount)
        {
            var fee = Math.Round(amount * 0.0349m, 2);
            return (fee, amount - fee);
        }
    }

    public class SecurePayFeeCalculator
    {
        public (decimal Fee, decimal Net) Calculate(decimal amount)
        {
            var fee = Math.Round(amount * 0.0299m + 0.40m, 2);
            return (fee, amount - fee);
        }
    }
}
