using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Application.DTOs;

namespace TVShowTracker.Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetGenresAsync();
        Task<GenreDTO> GetByIdAsync(int? id);
        Task AddAsync(GenreDTO genreDTO);
        Task RemoveAsync(int? id);
        Task UpdateAsync(GenreDTO genreDTO);
    }
}