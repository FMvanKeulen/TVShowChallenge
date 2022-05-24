using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVShowTracker.Application.DTOs;
using TVShowTracker.Application.Interfaces;
using TVShowTracker.Domain.Entities;
using TVShowTracker.Domain.Interfaces;

namespace TVShowTracker.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(GenreDTO genreDTO)
        {
            var genreEntity = _mapper.Map<Genre>(genreDTO);
            await _repository.Create(genreEntity);
        }

        public async Task<GenreDTO> GetByIdAsync(int? id)
        {
            var genreEntity = await _repository.GetById(id);
            return _mapper.Map<GenreDTO>(genreEntity);
        }

        public async Task<IEnumerable<GenreDTO>> GetGenresAsync()
        {
            var genresEntity = await _repository.GetGenres();
            return _mapper.Map<IEnumerable<GenreDTO>>(genresEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var genreEntity = await _repository.GetById(id);
            await _repository.Remove(genreEntity);
        }

        public async Task UpdateAsync(GenreDTO genreDTO)
        {
            var genreEntity = _mapper.Map<Genre>(genreDTO);
            await _repository.Update(genreEntity);
        }
    }
}