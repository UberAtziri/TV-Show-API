using System.Linq;
using WebApi.Entities;

namespace WebApi.Interfaces
{
    public interface IGenreRepo
    {
        GenreEntity GetSingle(int id);
         void Add(GenreEntity item);
         void Delete(int id);
         GenreEntity Update(int id, GenreEntity item);
         IQueryable<GenreEntity> GetAll();
         int Count();
         bool Save();
         GenreEntity GetGenreEntityByGenre(string genre);
         bool isGenreExist(string genre);

    }
}