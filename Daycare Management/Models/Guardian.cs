using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daycare_Management.Models
{
    public class Guardian
    {
        [Key]
        public int GuardianId { get; set; }

        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }

        public virtual ObservableCollectionListSource<Child> Children { get; set; }
    }
}
