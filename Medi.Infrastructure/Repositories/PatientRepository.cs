using System.Collections.Generic;
using Medi.Core.Domain;
using Medi.Core.Repositories;
using Medi.Database;

namespace Medi.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MediContext _mediContext;

        public PatientRepository(MediContext mediContext)
        {
            _mediContext = mediContext;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _mediContext.Patients;
        }

        public Patient Add(Patient patient)
        {
            _mediContext.Patients.Add(patient);
            _mediContext.SaveChanges();

            return patient;
        }
    }
}