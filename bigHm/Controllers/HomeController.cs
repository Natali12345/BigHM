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
    public class HomeController : Controller
    {
        private DBContext _context;

        public HomeController(DBContext c)
        {
            _context = c;

        }
        public IActionResult Index()
        {
            return View();
        }


       

    }
}







