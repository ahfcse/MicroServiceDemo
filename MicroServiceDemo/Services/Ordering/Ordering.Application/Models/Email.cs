using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Models
{
    public class Email
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SendFrom { get; set; }

    }
}
