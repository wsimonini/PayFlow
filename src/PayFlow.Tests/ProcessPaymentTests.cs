using Xunit;
using PayFlow.Application.UseCases;
using PayFlow.Domain.Ports;
using PayFlow.Domain.Services;
using PayFlow.Infrastructure.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProcessPaymentTests
{
    [Fact]
    public async Task ShouldUseSecurePay_WhenAmountIsAbove100()
    {
        var providers = new List<IProviderPort> { new FastPayAdapter(), new SecurePayAdapter() };
        var useCase = new ProcessPaymentUseCase(providers, new FastPayFeeCalculator(), new SecurePayFeeCalculator());

        var result = await useCase.ExecuteAsync(150m, "BRL");

        Assert.Equal("SecurePay", result.Provider);
        Assert.Equal("approved", result.Status);
    }

    [Fact]
    public async Task ShouldUseFastPay_WhenAmountBelow100()
    {
        var providers = new List<IProviderPort> { new FastPayAdapter(), new SecurePayAdapter() };
        var useCase = new ProcessPaymentUseCase(providers, new FastPayFeeCalculator(), new SecurePayFeeCalculator());

        var result = await useCase.ExecuteAsync(80m, "BRL");

        Assert.Equal("FastPay", result.Provider);
    }
}
