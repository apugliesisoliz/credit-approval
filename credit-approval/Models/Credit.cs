using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace credit_approval.Models
{
    public class Credit
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "DateRequest is required")]
        public DateTime DateRequest { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "AiIndicator is required")]
        public int AiIndicator { get; set; }
        [Required(ErrorMessage = "ClientId is required")]
        public int ClientId { get; set; }
        public int AuthState { get; set; }
        [StringLength(50, ErrorMessage = "UserAuth can't be longer than 50 characters")]
        public string UserAuth { get; set; }
        public DateTime DateAuth { get; set; }
        public bool State { get; set; }

    }
}
