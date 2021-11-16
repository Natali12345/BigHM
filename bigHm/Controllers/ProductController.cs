using bigHm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bigHm.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private DBContext _context;

        public ProductController(DBContext c)
        {
            _context = c;

        }
       
       
        [Authorize]
        public async Task<IActionResult> ShowProducts(string price, string color, string searchString)
        {
           


            IQueryable<string> colorQuery = from m in _context.products
                                            orderby m.Color
                                            select m.Color;

            var query = _context.products.AsQueryable();


            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Color.Contains(searchString) ||
                s.Name.Contains(searchString) || s.Size.Contains(searchString));

            }



            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(x => x.Color == color);
            }



            switch (price)
            {
                case "1":

                    query = query.Where(x => x.ListPrice < 100);

                    break;

                case "2":
                    query = query.Where(x => x.ListPrice > 100 && x.ListPrice < 500);


                    break;

                case "3":



                    query = query.Where(x => x.ListPrice > 500 && x.ListPrice < 1000);
                    break;

                case "4":

                    query = query.Where(x => x.ListPrice > 1000);

                    break;
            }

            var colorGenreVM = new ProductGenreViewModel
            {
                Colors = new SelectList(await colorQuery.Distinct().ToListAsync()),
                Products = await query.ToListAsync()
            };

            return View(colorGenreVM);


        }
    }

}

