using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class CustomerDTO
    {

        public int? CustId { get; set; }


        public string? Address { get; set; }


        public string? City { get; set; }


        public string CustTypeCd { get; set; }


        public string FedId { get; set; }


        public string? PostalCode { get; set; }

        public string? State { get; set; }
  
        public DateOnly? IncorpDate { get; set; }

        public String? Name { get; set; }

        public String? StateId { get; set; }
        public DateOnly BirthDay { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }



    }
}
