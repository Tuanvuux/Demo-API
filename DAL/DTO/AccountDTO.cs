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
    public class AccountDTO
    {
        /*public int AccountId {  get; set; }
        public float? AvailBalance { get; set; }
        public DateOnly? CloseDate { get; set; }
        public DateOnly? LastActivityDay { get; set; }      
        public DateOnly OpenDate { get; set; }
        public float? PendingBalance { get; set; }
        public string? Status { get; set; }   
        public int CustId { get; set; }   
        public int OpenEmpId { get; set; }   
        public int OpenBranchId { get; set; }
        public string ProductCd { get; set; }*/
        public Account Account { get; set; }
        public String BranchName { get; set; }
        public String EmployeeName { get; set; }
        public String ProductName { get; set; }
        public String ProductTypeName { get; set; }
        public float? TotalBalance { get; set; }
        public List<AccountTransactionDTO> AccountTransaction { get; set; }  

    }
}
