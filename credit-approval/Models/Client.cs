using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace credit_approval.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(100, ErrorMessage = "LastName can't be longer than 100 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Adress is required")]
        [StringLength(100, ErrorMessage = "Adress can't be longer than 100 characters")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Calification is required")]
        [StringLength(50, ErrorMessage = "Calification can't be longer than 50 characters")]
        public string Calification { get; set; }
        public bool State { get; set; }

    }

}
