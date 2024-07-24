using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("BUSINESS")]
    public class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CUST_ID")]
        [Required]
        public int CustId { get; set; }



        [Column("INCORP_DATE")]
        [DataType(DataType.Date)]
        public DateTime? IncorpDate {  get; set; }

        [Column("NAME")]
        [StringLength(255)]
        public String? Name {  get; set; }  

        [Column("STATE_ID")]
        [StringLength(10)]
        public String? StateId {  get; set; }




    }
}
