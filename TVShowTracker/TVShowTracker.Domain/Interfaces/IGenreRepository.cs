using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Domain.Entities;

namespace TVShowTracker.Domain.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetGenres();
        Task<Genre> GetById(int? id);
        Task<Genre> Create(Genre genre);
        Task<Genre> Update(Genre genre);
        Task<Genre> Remove(Genre genre);
    }
}