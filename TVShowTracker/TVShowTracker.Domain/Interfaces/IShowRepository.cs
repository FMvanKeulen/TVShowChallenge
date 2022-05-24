using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Domain.Entities;

namespace TVShowTracker.Domain.Interfaces
{
    public interface IShowRepository
    {
        Task<IEnumerable<Show>> GetShows();
        Task<Show> GetById(int? id);
        Task<Show> Create(Show show);
        Task<Show> Update(Show show);
        Task<Show> Remove(Show show);
    }
}