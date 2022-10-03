using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MachineCategory
    {
        [Key]
        public int MachineCategoryId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Machine> Machines { get; set; }


    }
}
