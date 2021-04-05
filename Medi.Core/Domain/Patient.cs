using System;

namespace Medi.Core.Domain
{
    public class Patient : Entity
    {
        public string Name { get; private set; }

        public string Surname { get; private set; }
        
        public string Occupation { get; private set; }
        
        public string PhoneNumber { get; private set; }

        public DateTime DateOfBirth { get; private set; }
        
        public Guid LeadDoctorId { get; private set; }
        
        public DateTime FirstDayInHospital { get; private set; }
        
        public DateTime LastDayInHospital { get; private set; }
        
        public Patient(Guid id, 
                       string name, 
                       string surname, 
                       string occupation, 
                       string phoneNumber, 
                       DateTime dateOfBirth, 
                       DateTime firstDayInHospital)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Occupation = occupation;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            FirstDayInHospital = firstDayInHospital;
        }
        //todo: Add collection of medicines
    }
}