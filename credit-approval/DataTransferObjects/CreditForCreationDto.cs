using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace credit_approval.DataTransferObjects
{
    public class CreditForCreationDto
    {
        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "AiIndicator is required")]
        public int AiIndicator { get; set; }
        [Required(ErrorMessage = "ClientId is required")]
        public int ClientId { get; set; }
        public bool State { get; set; }
    }
}
