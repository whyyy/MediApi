using System;

namespace Medi.Core.Domain
{
    public class Doctor
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public Specialization Specialization { get; set; }

        public DateTime AddedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

        public Doctor(Guid id, string name, string surname, Specialization specialization)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Specialization = specialization;
            AddedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}