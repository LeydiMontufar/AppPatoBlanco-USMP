using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AppPatoBlanco_USMP.Models;
using AppPatoBlanco_USMP.Data;
using Microsoft.AspNetCore.Mvc;

namespace AppPatoBlanco_USMP.Controllers
{
 
    public class MenuController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context,ILogger<ProductoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var productos = from o in _context.Productos select o;
            
            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var productos = from o in _context.Productos select o;
            Producto objProduct = await _context.Productos.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
        
            return View(objProduct);
        }
        
        
    }
}