using Microsoft.EntityFrameworkCore;
using TiendaMicroServicios.Api.Cupon.Models;

namespace TiendaMicroServicios.Api.Cupon.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }

        public DbSet<TiendaMicroServicios.Api.Cupon.Models.Cupon> Cupons { get; set; }
    }
}
