using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Title { get; set; }

        public ICollection<Personal> Personals { get; set; }
    }
}
