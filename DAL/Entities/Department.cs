using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("DEPARTMENT")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DEPT_ID")]
        [Required]
        public int DeptId { get; set; }

        [Column("NAME")]
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
    }
}
