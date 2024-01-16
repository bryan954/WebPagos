using Microsoft.EntityFrameworkCore;

namespace WebPagos.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Autor> Autores { get; set; }
}
