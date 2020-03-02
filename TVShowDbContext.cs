using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi
{
    public class TVShowDbContext : DbContext
    {
        public TVShowDbContext(DbContextOptions<TVShowDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TVShowGenre>().HasKey(x=> new {x.TVShowId, x.GenreId});

            builder.Entity<TVShowGenre>()
                .HasOne(g=>g.Genre)
                .WithMany(tg=>tg.TVShowGenre)
                .HasForeignKey(g => g.GenreId);
            
            builder.Entity<TVShowGenre>()
                .HasOne(m=>m.TVShow)
                .WithMany(ma=>ma.TVShowGenre)
                .HasForeignKey(a=>a.TVShowId);
        }
         public DbSet<TVShowEntity> TVShowItems {get; set;}
         public DbSet<TVShowGenre> TVShowGenreItems {get; set;}
         public DbSet<GenreEntity> GenreItems {get; set;}
        
    }
}