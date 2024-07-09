using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("BRANCH")]
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BRANCH_ID")]
        [Required]
        public int BranchId { get; set; }
        [Column("ADDRESS")]
        [StringLength(30)]
        public string? Address { get; set; }

        [Column("CITY")]
        [StringLength(20)]
        public string? City { get; set; }

        [Column("NAME")]
        [StringLength(20)]
        [Required]
        public string Name { get; set; }

        [Column("STATE")]
        [StringLength(10)]
        public string? State { get; set; }

        [Column("ZIP_CODE")]
        [StringLength(12)]
        public string? ZipCode { get; set; }

    }
}
