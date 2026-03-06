using Microsoft.EntityFrameworkCore;
using Sarmiento_ELNET1_MVC.Models;

namespace Sarmiento_ELNET1_MVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}