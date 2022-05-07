using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppPatoBlanco_USMP.Controllers
{
    
    public class MetodoPago : Controller
    {
        private readonly ILogger<MetodoPago> _logger;

        public MetodoPago(ILogger<MetodoPago> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}