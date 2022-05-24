using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Application.DTOs;
using TVShowTracker.Application.Interfaces;
using TVShowTracker.Domain.Entities;
using TVShowTracker.Domain.Interfaces;

namespace TVShowTracker.Application.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _repository;
        private readonly IMapper _mapper;

        public EpisodeService(IEpisodeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(EpisodeDTO episodeDTO)
        {
            var episodeEntity = _mapper.Map<Episode>(episodeDTO);
            await _repository.Create(episodeEntity);
        }

        public async Task<EpisodeDTO> GetByIdAsync(int? id)
        {
            var episodeEtity = await _repository.GetById(id);
            return _mapper.Map<EpisodeDTO>(episodeEtity);
        }

        public async Task<IEnumerable<EpisodeDTO>> GetEpisodesAsync()
        {
            var episodeEntities = await _repository.GetEpisodes();
            return _mapper.Map<IEnumerable<EpisodeDTO>>(episodeEntities);
        }

        public async Task RemoveAsync(int? id)
        {
            var episodeEntity = await _repository.GetById(id);
            await _repository.Remove(episodeEntity);
        }

        public async Task UpdateAsync(EpisodeDTO episodeDTO)
        {
            var episodeEntity = _mapper.Map<Episode>(episodeDTO);
            await _repository.Update(episodeEntity);
        }
    }
}