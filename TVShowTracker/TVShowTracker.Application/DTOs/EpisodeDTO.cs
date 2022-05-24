using System;
using System.ComponentModel.DataAnnotations;

namespace TVShowTracker.Application.DTOs
{
    public class EpisodeDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}