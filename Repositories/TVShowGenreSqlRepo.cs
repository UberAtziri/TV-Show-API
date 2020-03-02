using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;

namespace WebApi.Repositories
{
    public class TVShowGenreSqlRepo : ITVShowGenres
    {
        private readonly TVShowDbContext _context;
        public TVShowGenreSqlRepo(TVShowDbContext context)
        {
            _context = context;
        }
        public void Add(TVShowGenre item)
        {
            _context.TVShowGenreItems.Add(item);
        }

        public int Count()
        {
            return _context.TVShowGenreItems.Count();
        }

        public void Delete(string title, string genre)
        {
            var item = _context.TVShowGenreItems.FirstOrDefault(x=>x.TVShow.Title == title && x.Genre.Genre == genre);
            _context.TVShowGenreItems.Remove(item);
        }

        public IQueryable<TVShowGenre> GetAll()
        {
            return _context.TVShowGenreItems.Include(x=>x.Genre).Include(x=>x.TVShow).AsQueryable();
        }


        public bool Save()
        {
            return (_context.SaveChanges()>=0);
        }

        List<TVShowGenre> ITVShowGenres.GetByTVShow(string title)
        {
            return _context.TVShowGenreItems.Where(x=>x.TVShow.Title.ToLower() == title.ToLower()).Include(x=>x.Genre).Include(x=>x.TVShow).ToList();
        }

        public List<TVShowGenre> GetByGenre(string genre)
        {
            return _context.TVShowGenreItems.Where(x=>x.Genre.Genre.ToLower() == genre.ToLower()).Include(x=>x.Genre).Include(x=>x.TVShow).ToList();
        }
    }
}