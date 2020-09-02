using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace credit_approval.DataTransferObjects
{
    public class UserForUpdate
    {
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password can't be longer than 100 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "CanModCredit is required")]
        public bool CanModCredit { get; set; }
        [Required(ErrorMessage = "MaxAmountAuthCredit is required")]
        public double MaxAmountAuthCredit { get; set; }
    }
}
