using System.ComponentModel.DataAnnotations;

namespace TVShowTracker.Application.DTOs
{
    public class ActorDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nationality { get; set; }

        [Required]
        public bool HasOscar { get; set; }
    }
}