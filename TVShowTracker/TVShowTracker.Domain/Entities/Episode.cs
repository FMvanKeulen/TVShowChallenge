using System;
using TVShowTracker.Domain.Validation;

namespace TVShowTracker.Domain.Entities
{
    public sealed class Episode : Entity
    {
        public string Name { get; private set; }
        public DateTime ReleaseDate { get; private set; }

        public Episode(string name, DateTime releaseDate) =>
            ValidateDomain(name, releaseDate);

        public Episode(int id, string name, DateTime releaseDate)
        {
            DomainValidationException.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, releaseDate);
        }

        private void ValidateDomain(string name, DateTime releaseDate)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name), "Invalid name. Name is required.");
            DomainValidationException.When(string.IsNullOrEmpty(releaseDate.ToString()), "Invalid release date. Release date is required.");
            Name = name;
            ReleaseDate = releaseDate;
        }
    }
}