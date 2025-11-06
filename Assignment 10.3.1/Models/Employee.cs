using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_10._3._1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]// dont generate value, take from useryou
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; } // Foreign key to Department

        public virtual Department Department { get; set; } // sets up Navigation and the relationship
    }
}
