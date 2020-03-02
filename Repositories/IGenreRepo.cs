using System.Linq;
using WebApi.Entities;

namespace WebApi.Repositories
{
    public interface IGenreRepo
    {
        GenreEntity GetSingle(int id);
         void Add(GenreEntity item);
         void Delete(int id);
         GenreEntity Update(int id, GenreEntity item);
         IQueryable<GenreEntity> GetAll();
        //  GenreEntity GetRandomTVShowByGenre(string genre);
         int Count();
         bool Save();
         GenreEntity GetGenreEntityByGenre(string genre);

    }
}