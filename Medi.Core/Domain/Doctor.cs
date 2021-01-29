using System;

namespace Medi.Core.Domain
{
    public class Doctor : Entity
    {
        public string Name { get; private set; }

        public string Surname { get; private set; }

        public Specialization Specialization { get; private set;}

        public DateTime AddedAt { get; }
        
        public DateTime UpdatedAt { get; private set;}

        public Doctor(Guid id, string name, string surname, Specialization specialization)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Specialization = specialization;
            AddedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"Doctor with id: {Id} can't have a empty {nameof(Name)}");
            }

            Name = name;
            UpdatedAt = DateTime.Now;
        }
        
        public void SetSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new ArgumentNullException($"Doctor with id: {Id} can't have a empty {nameof(Surname)}");
            }

            Surname = surname;
            UpdatedAt = DateTime.Now;
        }

        public void SetSpecialization(Specialization specialization)
        {
            if (string.IsNullOrEmpty(specialization.ToString()))
            {
                throw new ArgumentNullException($"Doctor with id: {Id} can't have a empty {nameof(Specialization)}");
            }

            Specialization = specialization;
            UpdatedAt = DateTime.Now;
        }
    }
}