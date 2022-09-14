using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Models
{
    public class PersonalViewModel
    {
        public int PersonalId { get; set; }
        public string FullName { get; set; }
        public string Telephone { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int DepartmentId { get; set; }

    }
}
