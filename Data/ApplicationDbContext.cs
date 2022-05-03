using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppPatoBlanco_USMP.Models;
namespace AppPatoBlanco_USMP.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
     public DbSet<AppPatoBlanco_USMP.Models.Contacto> Consultas {get ;set; }
}
