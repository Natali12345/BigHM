using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bigHm.Models
{
    public class SearchModel
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string productNumber { get; set; }
        public string color { get; set; }
        public double size { get; set; }
        public double price { get; set; }
    }
}
