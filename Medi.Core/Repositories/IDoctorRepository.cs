using System;
using System.Collections.Generic;
using Medi.Core.Domain;

namespace Medi.Core.Repositories
{
    public interface IDoctorRepository
    {
        Doctor Get(Guid id);

        IEnumerable<Doctor> GetAll();

        Doctor Add(Doctor doctor);

        void Update(Doctor doctor);

        void Delete(Doctor doctor);
    }
}