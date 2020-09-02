using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace credit_approval.DataTransferObjects
{
    public class CreditForApproveDto
    {
        [Required(ErrorMessage = "UserAuth is required")]
        [StringLength(50, ErrorMessage = "UserAuth can't be longer than 200 characters")]
        public string UserAuth { get; set; }
    }
}
