using ContasAPagar.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContasAPagar.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Bill> Bills { get; set; }
    }
}