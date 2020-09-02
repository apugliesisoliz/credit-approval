using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace credit_approval.DataTransferObjects
{
    public class CreditForUpdate
    {
        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "DateRequest is required")]
        public DateTime DateRequest { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "AiIndicator is required")]
        public int AiIndicator { get; set; }
    }
}
