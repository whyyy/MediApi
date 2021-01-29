using System;
using System.Collections.Generic;
using Medi.Core.Domain;
using Medi.WebApi.DTO;

namespace Medi.WebApi.Services
{
    public interface IDoctorService
    {
        DoctorDto Get(Guid id);

        IEnumerable<DoctorDto> GetAll();

        DoctorDto Add(string name, string surname, Specialization specialization);

        void Update(Guid id, string name, string surname, Specialization specialization);

        void Delete(Guid id);
    }
}