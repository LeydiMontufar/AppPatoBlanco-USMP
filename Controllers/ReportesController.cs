using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AppPatoBlanco_USMP.Data;
using AppPatoBlanco_USMP.Models;

namespace AppPatoBlanco_USMP.Controllers
{
   
    public class ReportesController : Controller
    {
        private readonly ILogger<ReportesController> _logger;
        private readonly ApplicationDbContext _context;
         private readonly UserManager<IdentityUser> _userManager;


        public ReportesController(ILogger<ReportesController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

       
         public async Task<IActionResult> Reportes()
        {
        var userID = _userManager.GetUserName(User);
        var applicationDbContext = _context.DataProforma.Include(c => c.Producto);            
        return View(await applicationDbContext.ToListAsync());  

          }

        
    }
}