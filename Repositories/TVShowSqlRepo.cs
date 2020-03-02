using WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;

namespace WebApi.Repositories
{
    public class TVShowSqlRepo : ITVShowRepo
    {
        private readonly TVShowDbContext _context;
        private readonly Random _random;
        private readonly ITVShowGenres _tvgenre;
        public TVShowSqlRepo(TVShowDbContext context, ITVShowGenres tvgenres )
        {
            _context = context;
            _random = new Random();
            _tvgenre = tvgenres;
        }
        public TVShowEntity GetSingle(int id)
        {
            return _context.TVShowItems.Include(x=>x.TVShowGenre).ThenInclude(c=>c.Genre).FirstOrDefault(x => x.TVShowId == id);
        }
        public void Add(TVShowEntity item)
        {
            _context.TVShowItems.Add(item);
        }
        
        public void Delete(int id)
        {
            TVShowEntity tvItem = GetSingle(id);
            _context.TVShowItems.Remove(tvItem);
        }

        public TVShowEntity Update(int id, TVShowEntity item)
        {
            _context.TVShowItems.Update(item);
            return item;
        }
        public IQueryable<TVShowEntity> GetAll()
        {
            
            return _context.TVShowItems.Include(x=>x.TVShowGenre).ThenInclude(g=>g.Genre).AsQueryable();
        }

        public int Count()
        {
            return _context.TVShowItems.Count();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }        
        public TVShowEntity GetRandomTVShowByGenre(string genre)
        {
            List<TVShowGenre> temp = _tvgenre.GetByGenre(genre);
            var randomTVShow = temp[_random.Next(temp.Count())];

                
            return GetTVShowByTitle(randomTVShow.TVShow.Title);      
        }

        public TVShowEntity GetTVShowByTitle(string title)
        {
            return _context.TVShowItems.FirstOrDefault(x=>x.Title.ToLower() == title.ToLower());
        }
    }
}