using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;

namespace WebApi.Interfaces
{
    public interface ITVShowGenres
    {
         List<TVShowGenre> GetByTVShow (string title);
         List<TVShowGenre> GetByGenre (string genre);
         void Add(TVShowGenre item);
         void Delete(string title, string genre);
         IQueryable<TVShowGenre> GetAll();
        //  TVShowEntity GetRandomTVShowByGenre(string genre);
         int Count();
         bool Save();
    }
}