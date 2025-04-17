using Microsoft.EntityFrameworkCore;
using MTKW_MyApi.Data;

namespace MTKW_MyApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Article> ARCTICLES { get; set; }
        public DbSet<Category> CATEGORIES { get; set; }



    }
}
