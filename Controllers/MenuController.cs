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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppPatoBlanco_USMP.Controllers
{
 
    public class MenuController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MenuController(ApplicationDbContext context,ILogger<ProductoController> logger,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager= userManager;
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
        public async Task<IActionResult> Add(int? id){
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] ="Por favor debe loguearse antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return View("Index",productos);
            }else{
                var producto = await _context.DataProducto.FindAsync(id);
                Proforma proforma =new Proforma();
                proforma.Producto = producto;
                proforma.Precio=producto.Precio;
                proforma.Cantidad=1;
                proforma.UserID=userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        
        
    }
}