using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AppPatoBlanco_USMP.Data;
using AppPatoBlanco_USMP.Models;

namespace AppPatoBlanco_USMP.Controllers
{

    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public UsuariosController(ApplicationDbContext context,   UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       public async Task<IActionResult> Usuarios()
        {
        var applicationDbContext = _context.DataProforma.Include(c => c.Producto);            
        return View(await applicationDbContext.ToListAsync());
        }

        
    }
}