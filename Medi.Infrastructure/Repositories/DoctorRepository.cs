using System;
using System.Collections.Generic;
using System.Linq;
using Medi.Core.Domain;
using Medi.Core.Repositories;
using Medi.Database;

namespace Medi.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MediContext _mediContext;

        public DoctorRepository(MediContext mediContext)
        {
            _mediContext = mediContext;
        }
        
        public Doctor Get(Guid id)
        {
            return _mediContext.Doctors.SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _mediContext.Doctors;
        }

        public Doctor Add(Doctor doctor)
        {
            _mediContext.Doctors.Add(doctor);
            _mediContext.SaveChanges();
            
            return doctor;
        }

        public void Update(Doctor doctor)
        {
            var existingDoctor = _mediContext.Doctors.FirstOrDefault(d => d.Id == doctor.Id);

            if (existingDoctor is null)
            {
                return;
            }
            
            existingDoctor.SetName(doctor.Name);
            existingDoctor.SetSurname(doctor.Surname);
            existingDoctor.SetSpecialization(doctor.Specialization);
                
            _mediContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var existingDoctor = _mediContext.Doctors.FirstOrDefault(d => d.Id == id);

            if (existingDoctor is null)
            {
                return;
            }
            
            _mediContext.Doctors.Remove(existingDoctor);
            _mediContext.SaveChanges();
        }
    }
}