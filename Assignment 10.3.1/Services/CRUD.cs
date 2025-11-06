using Assignment_10._3._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_10._3._1.Data;

namespace Assignment_10._3._1.Services
{
    public class CRUD
    {
        public void AddEmployee(Employee emp)
        {
            // Code to add an employee
            Records.context.Employees.Add(emp);
            Records.context.SaveChanges();
        }
        public List<Employee> GetEmployees()
        {
            // Code to retrieve all employees
            return Records.context.Employees.ToList();
        }
        public Employee GetEmployeeById(string id)
        {
            // Code to retrieve an employee by ID
            return Records.context.Employees.Find(id);
        }
        public void DeleteEmployee(string id)
        {
            // Code to delete an employee by ID
            Employee emp = Records.context.Employees.Find(id);
            if (emp != null)
            {
                Records.context.Employees.Remove(emp);
                Records.context.SaveChanges();
            }
        }
        public void UpdateEmployee(string id, Employee emp)
        {
            // Code to update an employee
            Employee existingEmp = Records.context.Employees.Find(id);
            if (existingEmp != null)
            {
                existingEmp.EmployeeName = emp.EmployeeName;
                existingEmp.Salary = emp.Salary;
                existingEmp.DepartmentId = emp.DepartmentId;
                Records.context.SaveChanges();
            }
        }

    }
}
