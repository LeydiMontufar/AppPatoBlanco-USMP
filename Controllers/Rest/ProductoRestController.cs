using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppPatoBlanco_USMP.Data;
using AppPatoBlanco_USMP.Models;

namespace AppPatoBlanco_USMP.Controllers.Rest
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoRestController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoRestController(ApplicationDbContext context){
             _context = context;
        }

        [HttpGet]
        public IEnumerable<Producto> ListProductos()
        {
             var listProductos=_context.Productos.OrderBy(s => s.Id).ToList();   
             return listProductos.ToArray();
        }
        
    }
}