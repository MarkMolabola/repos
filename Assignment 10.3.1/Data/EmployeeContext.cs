using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_10._3._1.Models;

namespace Assignment_10._3._1.Data
{

    //represents a session with the database and allows querying and saving data
    public class EmployeeContext: DbContext
    {
        public DbSet<Department> Departments { get; set; } //table of Departments
        public DbSet<Employee> Employees { get; set; } // table of Employees

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use SQL Server with a connection string
            optionsBuilder.UseSqlServer("data source=MARKSALNWR2;initial catalog=PCAD18Employees;integrated security=True;encrypt=False;trustservercertificate=True;MultipleActiveResultSets=True");
        }

        //seeds the database with initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dummy data for Departments
            modelBuilder.Entity<Department>().HasData(
                   new Department { DepartmentId = 1, DepartmentName = "IT", Location = "New York" },
                   new Department { DepartmentId = 2, DepartmentName = "HR", Location = "Chicago" },
                   new Department { DepartmentId = 3, DepartmentName = "Marketing", Location = "Houston" });
            modelBuilder.Entity<Employee>().HasData(
                 new Employee { EmployeeId = "ADDII-12", EmployeeName = "Amy", Salary = 60000, DepartmentId = 1 }
                );
        }
    }
}
