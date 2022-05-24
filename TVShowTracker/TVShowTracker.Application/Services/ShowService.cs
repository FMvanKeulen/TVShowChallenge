using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Application.DTOs;
using TVShowTracker.Application.Interfaces;
using TVShowTracker.Domain.Entities;
using TVShowTracker.Domain.Interfaces;

namespace TVShowTracker.Application.Services
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository _repository;
        private readonly IMapper _mapper;

        public ShowService(IShowRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ShowDTO showDTO)
        {
            var showEntity = _mapper.Map<Show>(showDTO);
            await _repository.Create(showEntity);
        }

        public async Task<ShowDTO> GetByIdAsync(int? id)
        {
            var showEntity = await _repository.GetById(id);
            return _mapper.Map<ShowDTO>(showEntity);
        }

        public async Task<IEnumerable<ShowDTO>> GetShowsAsync()
        {
            var showEntities = await _repository.GetShows();
            return _mapper.Map<IEnumerable<ShowDTO>>(showEntities);
        }

        public async Task RemoveAsync(int? id)
        {
            var showEntity = await _repository.GetById(id);
            await _repository.Remove(showEntity);
        }

        public async Task UpdateAsync(ShowDTO showDTO)
        {
            var showEntity = _mapper.Map<Show>(showDTO);
            await _repository.Update(showEntity);
        }
    }
}