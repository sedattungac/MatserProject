using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int BlogCategoryId { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }
    }
}
