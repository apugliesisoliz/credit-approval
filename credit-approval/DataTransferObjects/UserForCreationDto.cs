using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace credit_approval.DataTransferObjects
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "UserId is required")]
        [StringLength(100, ErrorMessage = "UserId can't be longer than 100 characters")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password can't be longer than 100 characters")]
        public string Password { get; set; }
    }
}
