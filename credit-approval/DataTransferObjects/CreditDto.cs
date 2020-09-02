using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace credit_approval.DataTransferObjects
{
    public class CreditDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateRequest { get; set; }
        public double Amount { get; set; }
        public int AiIndicator { get; set; }
        public int ClientId { get; set; }
        public int AuthState { get; set; }
        public string UserAuth { get; set; }
        public DateTime DateAuth { get; set; }
        public bool State { get; set; }
    }
}
