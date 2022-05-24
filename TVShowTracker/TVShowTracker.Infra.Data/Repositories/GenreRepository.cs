using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Domain.Entities;
using TVShowTracker.Domain.Interfaces;
using TVShowTracker.Infra.Data.Context;

namespace TVShowTracker.Infra.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context) =>
            _context = context;

        public async Task<Genre> Create(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> GetById(int? id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> Remove(Genre genre)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> Update(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
    }
}