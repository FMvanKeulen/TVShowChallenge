using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Domain.Entities;

namespace TVShowTracker.Domain.Interfaces
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<Episode>> GetEpisodes();
        Task<Episode> GetById(int? id);
        Task<Episode> Create(Episode episode);
        Task<Episode> Update(Episode episode);
        Task<Episode> Remove(Episode episode);
    }
}