using System.Collections.Generic;
using TVShowTracker.Domain.Validation;

namespace TVShowTracker.Domain.Entities
{
    public sealed class Actor : Entity
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Nationality { get; private set; }
        public bool HasOscar { get; private set; }
        public ICollection<Show> Shows { get; set; }

        public Actor(string name, int age, string nationality, bool hasOscar)
        {
            ValidateDomain(name, age, nationality);
            HasOscar = hasOscar;
        }

        public Actor(int id, string name, int age, string nationality, bool hasOscar)
        {
            DomainValidationException.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, age, nationality);
            HasOscar = hasOscar;
        }

        public void Update(string name, int age, string nationality, bool hasOscar)
        {
            ValidateDomain(name, age, nationality);
            HasOscar = hasOscar;
        }

        public void ValidateDomain(string name, int age, string nationality)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name), "Invalid name. Name is required.");
            DomainValidationException.When(name.Length < 5, "Invalid name. Name is too short. Minimum 5 characters");
            DomainValidationException.When(string.IsNullOrEmpty(nationality) || string.IsNullOrWhiteSpace(nationality), "Invalid nationality. Nationality is required.");
            DomainValidationException.When(nationality.Length < 3, "Invalid name. Name is too short. Minimum 3 characters");
            DomainValidationException.When(age < 0, "Invalid age. Age must be bigger than 0");
            Name = name;
            Age = age;
            Nationality = nationality;
        }
    }
}