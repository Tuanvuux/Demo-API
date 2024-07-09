using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("PRODUCT_TYPE")]
    public class ProductType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PRODUCT_TYPE_CD")]
        [StringLength(10)]
        [Required]
        public string ProductTypeCd { get; set; }

        [Column("NAME")]
        [StringLength(50)]
        public string? Name { get; set; }
        
    }
}
