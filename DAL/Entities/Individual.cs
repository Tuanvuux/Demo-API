using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("INDIVIDUAL")]
    public class Individual
    {
        [Key]
        [Column("CUST_ID")]
        [Required]
        public int Cust_Id { get; set; }


        [Column("BIRTH_DAY")]
        [DataType(DataType.Date)]
        [Required]
        public DateOnly BirthDay { get; set; }

        [Column("FIRST_NAME")]
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }

        [Column("LAST_NAME")]
        [StringLength(30)]
        [Required]
        public string LastName { get; set; }

      
    }
}
