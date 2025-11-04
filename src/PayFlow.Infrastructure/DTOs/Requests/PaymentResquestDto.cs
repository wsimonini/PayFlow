using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlow.Infrastructure.DTOs.Requests
{
    public class PaymentResquestDto
    {
        public decimal Amount { get; set; }
        public string Currency {  get; set; }
    }
}
