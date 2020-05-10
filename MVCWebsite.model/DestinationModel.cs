using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebsite.model
{
   public  class DestinationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool? IsOffer { get; set; }
        public string ImagePath { get; set; }
    }
}
