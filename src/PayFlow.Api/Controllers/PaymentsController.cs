using Microsoft.AspNetCore.Mvc;
using PayFlow.Api.DTOs.Requests;
using PayFlow.Api.DTOs.Responses;
using PayFlow.Application.UseCases;
using PayFlow.Infrastructure.DTOs.Requests;
using PayFlow.Infrastructure.Providers.SecurePay.DTOs;
using System.Threading.Tasks;

namespace PayFlow.Api.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly ProcessPaymentUseCase _useCase;

        public PaymentsController(ProcessPaymentUseCase useCase) => _useCase = useCase;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentResquestDto request)
        {
            var payment = await _useCase.ExecuteAsync(request.Amount, request.Currency);

            var response = new PaymentResponseDto
            {
                ExternalId = payment.ExternalId,
                Status = payment.Status,
                Provider = payment.Provider,
                GrossAmount = payment.GrossAmount,
                Fee = payment.Fee,
                NetAmount = payment.NetAmount,
                Currency = payment.Currency
            };

            return Ok(response);
        }

        [HttpPost("fastpay")]
        public async Task<ActionResult<PaymentResponseDto>> Post([FromBody] FastPayRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var payment = await _useCase.ExecuteAsync(request.TransactionAmount, request.Currency);

            var response = new PaymentResponseDto
            {
                ExternalId = payment.ExternalId,
                Status = payment.Status,
                Provider = payment.Provider,
                GrossAmount = payment.GrossAmount,
                Fee = payment.Fee,
                NetAmount = payment.NetAmount,
                Currency = payment.Currency
            };

            return Ok(response);
        }

        [HttpPost("securepay")]
        public async Task<IActionResult> PostSecurePay([FromBody] SecurePayRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var payment = await _useCase.ExecuteAsync(request.AmountCents, request.CurrencyCode);

            var response = new SecurePayResponseDto
            {
                TransactionId = payment.ExternalId,
                Result = payment.Status
            };

            return Ok(response);
        }
    }
}
