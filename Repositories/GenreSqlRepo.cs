using System.Linq;
using WebApi.Entities;

namespace WebApi.Repositories
{
    public class GenreSqlRepo : IGenreRepo
    {
        private readonly TVShowDbContext _context;
        public GenreSqlRepo(TVShowDbContext context)
        {
            _context = context;
        }
        
        public void Add(GenreEntity item)
        {
            _context.GenreItems.Add(item);
        }

        public int Count()
        {
            return _context.GenreItems.Count();
        }

        public void Delete(int id)
        {
            var item = GetSingle(id);
            _context.GenreItems.Remove(item);
        }

        public IQueryable<GenreEntity> GetAll()
        {
            return _context.GenreItems.AsQueryable();
        }

        public GenreEntity GetGenreEntityByGenre(string genre)
        {
            return _context.GenreItems.FirstOrDefault(x=>x.Genre.ToLower() == genre.ToLower());
        }

        public GenreEntity GetSingle(int id)
        {
            return _context.GenreItems.FirstOrDefault(x=>x.GenreId == id);
        }

        public bool Save()
        {
            return(_context.SaveChanges() >= 0);
        }

        public GenreEntity Update(int id, GenreEntity item)
        {
            _context.GenreItems.Update(item);
            return item;
        }
    }
}