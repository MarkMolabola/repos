using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_12._3._2_CRUDappMAUI.Models;

namespace Assignment_12._3._2_CRUDappMAUI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Child> children { get; set; }
        public DbSet<Guardian> guardian { get; set; }
    }
}
