using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class Seed : ISeed
    {
        public async Task Initialize (TVShowDbContext context)
        {
         context.TVShowItems.Add(new TVShowEntity(){Title = "True Detective", Genre = "Drama", ImdbScore = 9.0 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "Killing Eve", Genre = "Action", ImdbScore = 8.3 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "The Haunting of Hill House", Genre = "Horror", ImdbScore = 8.7 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "Sex Education", Genre = "Comedy", ImdbScore = 8.3 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "Dark", Genre = "Mystery", ImdbScore = 8.7 });  
         context.TVShowItems.Add(new TVShowEntity(){Title = "Random1", Genre = "Drama", ImdbScore = 9.0 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "Random2", Genre = "Drama", ImdbScore = 9.0 });   
         context.TVShowItems.Add(new TVShowEntity(){Title = "Random3", Genre = "Drama", ImdbScore = 9.0 });   

         await context.SaveChangesAsync(); 
        }
    }
}