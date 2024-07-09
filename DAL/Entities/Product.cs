using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("PRODUCT")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PRODUCT_CD")]
        [StringLength(2)]
        [Required]
        public string ProductCd { get; set; }

        [Column("DATE_OFFERED")]
        [DataType(DataType.Date)]
        public DateTime? DateOffered { get; set; }

        [Column("DATE_RETIRED")]
        [DataType(DataType.Date)]
        public DateTime? DateRetired { get; set; }

        [Column("Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Column("PRODUCT_TYPE_CD")]
        [StringLength(10)]
        public string? ProductTypeCd;

    }
}
