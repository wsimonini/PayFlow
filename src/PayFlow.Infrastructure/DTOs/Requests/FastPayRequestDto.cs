using System.ComponentModel.DataAnnotations;

namespace PayFlow.Api.DTOs.Requests
{
    public class FastPayRequestDto
    {

        [Required(ErrorMessage = "O campo 'amount' é obrigatório.")]
        public decimal TransactionAmount { get; set; }

        [Required(ErrorMessage = "O campo 'currency' é obrigatório.")]
        public string Currency { get; set; } = string.Empty;

        public PayerDto Payer { get; set; } = new();

        public int Installments { get; set; }

  
        public string Description { get; set; } = string.Empty;
    }

    public class PayerDto
    {
        public string Email { get; set; } = string.Empty;
    }
}
