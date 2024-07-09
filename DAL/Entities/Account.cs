using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("ACCOUNT")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ACCOUNT_ID")]
        [Required]
        public int Account_Id { get; set; }

        [Column("AVAIL_BALANCE")]
        public float? AvailBalance { get; set; }

        [Column("CLOSE_DATE")]
        [DataType(DataType.Date)]
        public DateOnly? CloseDate { get; set; }

        [Column("LAST_ACTIVITY_DATE")]
        [DataType(DataType.Date)]
        public DateOnly? LastActivityDay { get; set; }

        [Column("OPEN_DATE")]
        [DataType(DataType.Date)]
        [Required]
        public DateOnly OpenDate { get; set; }

        [Column("PENDING_BALANCE")]

        public float? PendingBalance { get; set; }

        [Column("STATUS")]
        [StringLength(10)]
        public string? Status { get; set; }

        [Column("CUST_ID")]
        public int? CustId;
        [Column("OPEN_EMP_ID")]
        [Required]
        public int OpenEmpId { get; set; }

        [Column("OPEN_BRANCH_ID")]
        [Required]
        public int OpenBranchId {get; set;}

        [Column("PRODUCT_CD")]
        [StringLength(10)]
        [Required]
        public string ProductCd {get; set;}
    }
}
