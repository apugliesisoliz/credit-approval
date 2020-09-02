using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace credit_approval.DataTransferObjects
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Calification { get; set; }
        public bool State { get; set; }
    }
}
