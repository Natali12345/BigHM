using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bigHm.Models
{
    public class ProductGenreViewModel
    {
        public List<Product> Products { get; set; }
        public SelectList Colors { get; set; }
        public string ColorGenre { get; set; } 
        public string SearchString { get; set; }
        public SelectList Prices { get; set; }

      
    }
}
