using ArqWebApp.Core.Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqWebApp.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cars> cars { get; set; }
    }
}