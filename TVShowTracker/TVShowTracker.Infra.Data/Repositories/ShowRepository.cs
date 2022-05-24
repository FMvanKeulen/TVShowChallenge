using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Domain.Entities;
using TVShowTracker.Domain.Interfaces;
using TVShowTracker.Infra.Data.Context;

namespace TVShowTracker.Infra.Data.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly ApplicationDbContext _context;

        public ShowRepository(ApplicationDbContext context) =>
            _context = context;

        public async Task<Show> Create(Show show)
        {
            _context.Shows.Add(show);
            await _context.SaveChangesAsync();
            return show;
        }

        public async Task<Show> GetById(int? id)
        {
            return await _context.Shows.FindAsync(id);
        }

        public async Task<IEnumerable<Show>> GetShows()
        {
            return await _context.Shows.ToListAsync();
        }

        public async Task<Show> Remove(Show show)
        {
            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
            return show;
        }

        public async Task<Show> Update(Show show)
        {
            _context.Entry(show).State = EntityState.Modified;
            _context.Shows.Update(show);
            await _context.SaveChangesAsync();
            return show;
        }
    }
}