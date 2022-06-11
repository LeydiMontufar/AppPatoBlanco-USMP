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
using Microsoft.AspNetCore.Http;

namespace AppPatoBlanco_USMP.Controllers
{
    public class ReservaController: Controller
    {
        private readonly ILogger<ReservaController> _logger;

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReservaController (ApplicationDbContext context, ILogger<ReservaController> logger,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager= userManager;
            
        }
        public IActionResult Index()
        {
            return View();
        }

          [HttpPost]
       public IActionResult Create(Reserva objReserva){

        
            _context.Add(objReserva);
            _context.SaveChanges();    
            ViewData["Message"] = "Se reservo su mesa";
            return View("Index");
            
        }
    }
}