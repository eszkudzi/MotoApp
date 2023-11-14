using Microsoft.EntityFrameworkCore;
using MotoApp.Entities;

namespace MotoApp.Data
{
    public class MotoAppDbContext : DbContext
    {
        public MotoAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }


    }
}
