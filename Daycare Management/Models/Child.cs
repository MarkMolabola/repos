using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daycare_Management.Models
{
    public class Child
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int GuardianID { get; set; }

        public virtual Guardian Guardian { get; set; }

    }
}
