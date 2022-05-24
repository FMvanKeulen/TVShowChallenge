using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Application.DTOs;

namespace TVShowTracker.Application.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<ActorDTO>> GetActorsAsync();
        Task<ActorDTO> GetByIdAsync(int? id);
        Task AddAsync(ActorDTO actorDTO);
        Task RemoveAsync(int? id);
        Task UpdateAsync(ActorDTO actorDTO);
    }
}