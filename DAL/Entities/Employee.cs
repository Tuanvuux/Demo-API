using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("EMPLOYEE")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EMP_ID")]
        [Required]
        public int EmpId { get; set; }

        [Column("END_DATE")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Column("FIRST_NAME")]
        [StringLength(20)]
        [Required]
        public string FirstName { get; set; }

        [Column("LAST_NAME")]
        [StringLength(20)]
        [Required]
        public string LastName { get; set; }

        [Column("START_DAY")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Column("TITLE")]
        [StringLength(20)]
        public string? Title {  get; set; }

        [Column("ASSIGNED_BRANCH_ID")]
        public int AssignedBranchId { get; set; }

        [Column("DEPT_ID")]
        public int DeptId {  get; set; }  

        [Column("SUPERIOR_EMP_ID")]
        public int SuperiorEmpId { get; set; }



    }
}
