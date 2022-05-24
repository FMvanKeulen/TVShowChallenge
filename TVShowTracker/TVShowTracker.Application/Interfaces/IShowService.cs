using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Application.DTOs;

namespace TVShowTracker.Application.Interfaces
{
    public interface IShowService
    {
        Task<IEnumerable<ShowDTO>> GetShowsAsync();
        Task<ShowDTO> GetByIdAsync(int? id);
        Task AddAsync(ShowDTO showDTO);
        Task RemoveAsync(int? id);
        Task UpdateAsync(ShowDTO showDTO);
    }
}