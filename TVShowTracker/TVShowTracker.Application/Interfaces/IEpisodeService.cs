using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Application.DTOs;

namespace TVShowTracker.Application.Interfaces
{
    public interface IEpisodeService
    {
        Task<IEnumerable<EpisodeDTO>> GetEpisodesAsync();
        Task<EpisodeDTO> GetByIdAsync(int? id);
        Task AddAsync(EpisodeDTO episodeDTO);
        Task RemoveAsync(int? id);
        Task UpdateAsync(EpisodeDTO episodeDTO);
    }
}