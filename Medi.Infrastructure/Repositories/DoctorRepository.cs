using System;
using System.Collections.Generic;
using System.Linq;
using Medi.Core.Domain;
using Medi.Core.Repositories;

namespace Medi.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private ISet<Doctor> _doctors = new HashSet<Doctor>();
        
        public Doctor Get(Guid id)
        {
            return _doctors.SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctors;
        }

        public Doctor Add(Doctor doctor)
        {
            _doctors.Add(doctor);
            
            return doctor;
        }

        public void Update(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor doctor)
        {
            _doctors.Remove(doctor);
        }
    }
}