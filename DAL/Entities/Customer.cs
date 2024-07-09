using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CUST_ID")]
        [Required]
        public int CustId { get; set; }

        [Column("ADDRESS")]
        [StringLength(30)]
        public string? Address { get; set; }

        [Column("CITY")]
        [StringLength(20)]
        public string? City { get; set; }

        [Column("CUST_TYPE_CD")]
        [StringLength(1)]
        [Required]
        public string CustTypeCd { get; set; }

        [Column("FED_ID")]
        [StringLength(12)]
        [Required]
        public string FedId { get; set; }

        [Column("POSTAL_CODE")]
        [StringLength(10)]
        public string? PostalCode { get; set; }

        [Column("STATE")]
        [StringLength(20)]
        public string? State { get; set; }
    }
}
