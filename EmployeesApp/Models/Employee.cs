using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Models
{
    [Table("Employee", Schema = "dbo")]
    public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        [MaxLength(5)]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [MaxLength(100)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        [DisplayFormat(DataFormatString ="{0:dd-MMMM-yyyy}")]
        public DateTime HiringDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Gross Salary")]
        public decimal GrossSalary{ get; set; }


        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Net Salary")]
        public decimal NetSalary { get; set; }


        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Department")]
        [NotMapped]
        public string DepartmentName { get; set; }


        public virtual Department Department { get; set; }


    }
}
