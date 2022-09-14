using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
