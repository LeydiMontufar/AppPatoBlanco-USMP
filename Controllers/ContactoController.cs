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
using AppPatoBlanco_USMP.Integration.Sendgrid;

namespace AppPatoBlanco_USMP.Controllers
{

    public class ContactoController : Controller 
    {
        private readonly ILogger<ContactoController> _logger;

        private readonly ApplicationDbContext _context;

         private readonly SendMailIntegration _sendgrid;
        public ContactoController (ApplicationDbContext context, ILogger<ContactoController> logger, SendMailIntegration sendgrid)
        {
            _context = context;
            _logger = logger;
             _sendgrid = sendgrid;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contacto objContacto){
        

            _context.Add(objContacto);
            _context.SaveChanges();

             await _sendgrid.SendMail(objContacto.Email,
            objContacto.Nombre,
            "Hola Bienvenido al PB",
            "Revisaremos tu consulta",
            SendMailIntegration.SEND_SENDGRID);



            ViewData["Message"] = "Se registro el contacto";

            return View("Index");
        }

        public IActionResult Confirmacion()
        {
            return View();
        }


        /*
        public IActionResult ListarConsultas(){
            var conssultas = _context.Consultas.ToList();
            return View(conssultas);

        }*/

        public async Task<IActionResult> ListarConsultas()
        {
            return View(await _context.Consultas.ToListAsync());
        }



        
    }
}