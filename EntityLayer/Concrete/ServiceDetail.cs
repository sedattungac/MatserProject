using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServiceDetail
    {
        [Key]
        public int ServiceDetailId { get; set; }
        public string MachineName { get; set; }
        public string PdfUrl { get; set; }

        public virtual Service Service { get; set; }
        public int ServiceId { get; set; }
    }
}
