using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebsite.model
{
   public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public bool? EmailSent { get; set; }
        public System.DateTime? TimeStamp { get; set; }
    }
}
