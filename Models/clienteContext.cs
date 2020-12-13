using Microsoft.EntityFrameworkCore;

namespace WebApiTienda.Models
{
    public class clienteContext : DbContext
    {
        public clienteContext(DbContextOptions<clienteContext> options)
            : base(options)
        {
        }

        public DbSet<clienteItem> clienteItems { get; set; }
    }
}