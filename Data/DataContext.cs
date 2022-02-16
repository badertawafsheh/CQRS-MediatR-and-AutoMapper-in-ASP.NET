using CQRS_With_MeditR_Demo.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
        public DbSet<Product> Products { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
