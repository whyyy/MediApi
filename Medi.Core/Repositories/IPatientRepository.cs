using System.Collections.Generic;
using Medi.Core.Domain;

namespace Medi.Core.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();

        Patient Add(Patient patient);
    }
}