using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TVShowTracker.Domain.Entities;

namespace TVShowTracker.Application.DTOs
{
    public class ShowDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Actor> Actors { get; private set; }
    }
}