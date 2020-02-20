using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Repositories
{
    public class TVShowDbContext : DbContext
    {
        public TVShowDbContext(DbContextOptions<TVShowDbContext> options)
            : base(options)
        {
            
        }
         public DbSet<TVShowEntity> TVShowItems {get; set;}
        
    }
}