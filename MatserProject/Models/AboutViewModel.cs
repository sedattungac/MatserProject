using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Models
{
    public class AboutViewModel
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
    }
}
