using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class CustomerDTORespond
    {
        public int CustId {  get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? IncorpDay { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? CustomerType { get; set; }
    }
}
