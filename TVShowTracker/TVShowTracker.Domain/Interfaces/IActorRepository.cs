using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Domain.Entities;

namespace TVShowTracker.Domain.Interfaces
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetActors();
        Task<Actor> GetById(int? id);
        Task<Actor> Create(Actor actor);
        Task<Actor> Update(Actor actor);
        Task<Actor> Remove(Actor actor);
        Task<IEnumerable<Actor>> GetShowsByActor(Actor actor);
    }
}