using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("ACC_TRANSACTION")]
    public class AccTransaction
    {
        [Column("TXN_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long Txn_Id {  get; set; }

        [Column("AMOUNT")]
        [Required]
        public float Amount { get; set; }

        [Column("FUNDS_AVAIL_DATE")]
        [Required]
        public DateTime Fund_Avail_Date { get; set; }

        [Column("TXN_DATE")]
        [Required]
        public DateTime TxnDate { get; set; }

        [Column("TXN_TYPE_CD")]
        [StringLength(10)]
        public string? TxnTypeCd {  get; set; }

        [Column("ACCOUNT_ID")]
        public int? AccountId { get; set; }

        [Column("EXCUTION_BRANCH_ID")]
        public int? ExcutionBranchId { get; set; }

        [Column("TELLER_EMP_ID")]
        public int? TellerEmpId { get; set; }


    }
}
