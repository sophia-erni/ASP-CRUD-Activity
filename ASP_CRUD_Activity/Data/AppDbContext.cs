using ASP_CRUD_Activity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_CRUD_Activity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Car> Car { get; set; }
    }
}
