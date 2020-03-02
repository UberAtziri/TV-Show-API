using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;

namespace WebApi.Interfaces
{
    public interface ITVShowRepo
    {
         TVShowEntity GetSingle(int id);
         void Add(TVShowEntity item);
         void Delete(int id);
         TVShowEntity Update(int id, TVShowEntity item);
         IQueryable<TVShowEntity> GetAll();
        //  TVShowEntity GetRandomTVShowByGenre(string genre);
         int Count();
         bool Save();
         TVShowEntity GetTVShowByTitle(string title);
         TVShowEntity GetRandomTVShowByGenre (string genre);

    }
}