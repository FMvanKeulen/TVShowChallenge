using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Application.DTOs;
using TVShowTracker.Application.Interfaces;
using TVShowTracker.Domain.Entities;
using TVShowTracker.Domain.Interfaces;

namespace TVShowTracker.Application.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _repository;
        private readonly IMapper _mapper;

        public ActorService(IActorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ActorDTO actorDTO)
        {
            var actorEntity = _mapper.Map<Actor>(actorDTO);
            await _repository.Create(actorEntity);
        }

        public async Task<IEnumerable<ActorDTO>> GetActorsAsync()
        {
            var actorEntities = await _repository.GetActors();
            return _mapper.Map<IEnumerable<ActorDTO>>(actorEntities);
        }

        public async Task<ActorDTO> GetByIdAsync(int? id)
        {
            var actorEntity = await _repository.GetById(id);
            return _mapper.Map<ActorDTO>(actorEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var actorEntity = await _repository.GetById(id);
            await _repository.Remove(actorEntity);
        }

        public async Task UpdateAsync(ActorDTO actorDTO)
        {
            var actorEntity = _mapper.Map<Actor>(actorDTO);
            await _repository.Update(actorEntity);
        }
    }
}