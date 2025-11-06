using Assignment_10._3._1.Data;
using Microsoft.EntityFrameworkCore;

namespace Assignment_10._3._1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Records.context = new EmployeeContext();
            Records.context.Database.EnsureCreated(); // Ensure the database is created
            Records.context.Departments.Load(); // Load Departments into context
            Records.context.Employees.Load(); // Load Employees into context
            Application.Run(new Form1());
        }
    }
}