using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Models
{
    public class SliderViewModel
    {
        public int SliderId { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
