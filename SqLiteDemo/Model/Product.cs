using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqLiteDemo.Model
{
    //domain model 
    public class Product
    {
       
        public int Id { get; set; }// will auto increment in the database
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int stock { get; set; }

    }
}
