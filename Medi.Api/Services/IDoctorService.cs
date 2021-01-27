using System;
using System.Collections.Generic;
using Medi.Core.Domain;
using MediAPI.DTO;

namespace MediAPI.Services
{
    public interface IDoctorService
    {
        DoctorDto Get(Guid id);

        IEnumerable<DoctorDto> GetAll();

        DoctorDto Add(string name, string surname, Specialization specialization);

        void Update(string name, string surname, Specialization specialization);

        void Delete(Guid id);
    }
}