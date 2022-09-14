using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Models
{
    public class BlogViewModel
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public IFormFile ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
