using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppPatoBlanco_USMP.Models;
using AppPatoBlanco_USMP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AppPatoBlanco_USMP.Controllers
{
  
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context,ILogger<ProductoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var productos = from o in _context.Productos select o;
            
            return View(await productos.ToListAsync());
        }

        
    }
}