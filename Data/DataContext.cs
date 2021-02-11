using Microsoft.EntityFrameworkCore;

namespace ContasAPagar.Data
{
    public class DataContext : DbContext
    {
        protected DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}