using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Models
{
    public class MachineViewModel
    {
        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public string ModelYear { get; set; }
        public string DeliveryDate { get; set; }
        public string Producer { get; set; }
        public string Dimension { get; set; }
        public IFormFile ImageUrl { get; set; }
        public IFormFile ImageUrl2 { get; set; }
        public IFormFile ImageUrl3 { get; set; }
        public IFormFile ImageUrl4 { get; set; }
        public string VideoUrl { get; set; }
        public int MachineCategoryId { get; set; }
    }
}
