using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace credit_approval.DataTransferObjects
{
    public class UserDto
    {
        public String UserId { get; set; }
        public string Password { get; set; }
        public DateTime DateUpdatePassword { get; set; }
        public DateTime DateValidityPassword { get; set; }
        public string Token { get; set; }
        public DateTime DateValidityToken { get; set; }
        public bool CanModCredit { get; set; }
        public double MaxAmountAuthCredit { get; set; }
        public bool State { get; set; }
    }
}
