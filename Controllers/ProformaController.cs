using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AppPatoBlanco_USMP.Data;
using AppPatoBlanco_USMP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;


namespace AppPatoBlanco_USMP.Controllers
{
   public class ProformaController: Controller
    {
        private readonly ILogger<MenuController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ProformaController(ApplicationDbContext context, ILogger<MenuController> logger, UserManager<IdentityUser> userManager){
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(){
            var  userID = _userManager.GetUserName(User);
            var items = from o in _context.DataProforma select o;
            items = items.Include(p => p.Producto).Where(w => w.UserID.Equals(userID) && w.Status.Equals("Pendiente"));

            var carrito = await items.ToListAsync();
            var total= carrito.Sum(c => c.Cantidad * c.Precio);

            dynamic model = new ExpandoObject();
            model.montoTotal = total;
            model.elementosCarrito = carrito;

             return View(model);
        }
    }
}