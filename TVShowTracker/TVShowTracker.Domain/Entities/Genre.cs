using TVShowTracker.Domain.Validation;

namespace TVShowTracker.Domain.Entities
{
    public sealed class Genre : Entity
    {
        public string Name { get; private set; }

        public Genre(string name) =>
            ValidateDomain(name);

        public Genre(int id, string name)
        {
            DomainValidationException.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name) =>
            ValidateDomain(name);

        private void ValidateDomain(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name), "Invalid name. Name is required.");
            DomainValidationException.When(name.Length < 5, "Invalid name. Name is too short. Minimum 5 characters.");
            Name = name;
        }
    }
}