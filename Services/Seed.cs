using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class Seed : ISeed
    {
        public async Task Initialize (TVShowDbContext context)
        {
        context.GenreItems.Add(new GenreEntity(){Genre = "Comedy"});
        context.GenreItems.Add(new GenreEntity(){Genre = "Horror"});
        context.GenreItems.Add(new GenreEntity(){Genre = "Drama"});
        context.GenreItems.Add(new GenreEntity(){Genre = "Mystery"});
         context.TVShowItems.Add(new TVShowEntity(){Title = "True Detective", ImdbScore = 9.0 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "Killing Eve", ImdbScore = 8.3 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "The Haunting of Hill House", ImdbScore = 8.7 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "Sex Education", ImdbScore = 8.3 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "Dark",  ImdbScore = 8.7 });  
         context.TVShowItems.Add(new TVShowEntity(){Title = "Random1",  ImdbScore = 9.0 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "Random2",ImdbScore = 9.0 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "Random3",  ImdbScore = 9.0 });
         TVShowEntity TVShow = context.TVShowItems.Where(x=>x.Title == "Sex Education").FirstOrDefault();
        context.TVShowGenreItems.Add(new TVShowGenre(){Genre = context.GenreItems.Where(x=>x.Genre == "Comedy").FirstOrDefault(), TVShow = context.TVShowItems.Where(x=>x.Title=="Sex Education").FirstOrDefault() });
        context.TVShowGenreItems.Add(new TVShowGenre(){TVShowId = 2, GenreId = 3});

         await context.SaveChangesAsync(); 
        }
    }
}