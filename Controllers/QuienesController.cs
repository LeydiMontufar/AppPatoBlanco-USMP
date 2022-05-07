using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppPatoBlanco_USMP.Controllers
{

    public class QuienesController : Controller
    {
        private readonly ILogger<QuienesController> _logger;

        public QuienesController(ILogger<QuienesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}