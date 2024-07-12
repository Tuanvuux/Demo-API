using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.DTO
{
    public class AccountTransactionDTO
    {
        //2.5.2
   
        public AccTransaction accTransaction { get; set; }

        public string BranchName {  get; set; }
        public String EmployeeName {  get; set; }
    }
}
