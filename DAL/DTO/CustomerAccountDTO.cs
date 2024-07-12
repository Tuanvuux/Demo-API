using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class CustomerAccountDTO
    {
        //2.5.2
        public int CustomerId {  get; set; }
        public float? TotalBalance { get; set; }
        public List<AccountDTO>? Accounts { get; set; }  

    }
}
