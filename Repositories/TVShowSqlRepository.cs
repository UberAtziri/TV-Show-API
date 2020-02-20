using WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Repositories
{
    public class TVShowSqlRepository : IRepository
    {
        private readonly TVShowDbContext _context;
        public TVShowSqlRepository(TVShowDbContext context)
        {
            _context = context;
        }
        public TVShowEntity GetSingle(int id)
        {
            return _context.TVShowItems.FirstOrDefault(x => x.Id == id);
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
            return _context.TVShowItems.AsQueryable();
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
            return _context.TVShowItems
                .Where(x => x.Genre.ToLower() == genre.ToLower())
                .OrderBy(o => Guid.NewGuid())
                .FirstOrDefault();
        }
    }
}