using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Email
    {
        [Key]
        public int EmailId { get; set; }
        public string EmailAddress { get; set; }
        public string Subjeft { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
