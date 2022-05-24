using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Domain.Entities;
using TVShowTracker.Domain.Interfaces;
using TVShowTracker.Infra.Data.Context;

namespace TVShowTracker.Infra.Data.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly ApplicationDbContext _context;

        public EpisodeRepository(ApplicationDbContext context) =>
            _context = context;

        public async Task<Episode> Create(Episode episode)
        {
            _context.Episodes.Add(episode);
            await _context.SaveChangesAsync();
            return episode;
        }

        public async Task<Episode> GetById(int? id)
        {
            return await _context.Episodes.FindAsync(id);
        }

        public async Task<IEnumerable<Episode>> GetEpisodes()
        {
            return await _context.Episodes.ToListAsync();
        }

        public async Task<Episode> Remove(Episode episode)
        {
            _context.Episodes.Remove(episode);
            await _context.SaveChangesAsync();
            return episode;
        }

        public async Task<Episode> Update(Episode episode)
        {
            _context.Episodes.Update(episode);
            await _context.SaveChangesAsync();
            return episode;
        }
    }
}