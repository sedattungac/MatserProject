using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public string ModelYear { get; set; }
        public string DeliveryDate { get; set; }
        public string Producer { get; set; }
        public string Dimension { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ImageUrl4 { get; set; }
        public string VideoUrl { get; set; }
        public int MachineCategoryId { get; set; }
        public virtual MachineCategory MachineCategory { get; set; }

    }
}
