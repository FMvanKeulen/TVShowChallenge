using System.Collections.Generic;
using TVShowTracker.Domain.Validation;

namespace TVShowTracker.Domain.Entities
{
    public class Show : Entity
    {
        public string Name { get; private set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Episode> Episodes { get; set; }

        public Show(string name) =>
            ValidateDomain(name);

        public Show(int id, string name)
        {
            DomainValidationException.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name) =>
            ValidateDomain(name);

        private void ValidateDomain(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainValidationException.When(name.Length < 3, "Invalid name. Name is too short. Minimum 3 characters.");
            Name = name;
        }
    }
}