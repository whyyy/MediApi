using System;
using System.Collections.Generic;
using AutoMapper;
using Medi.Core.Domain;
using Medi.Core.Repositories;
using MediAPI.DTO;

namespace MediAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        
        public DoctorDto Get(Guid id)
        {
            var doctor = _doctorRepository.Get(id);

            return _mapper.Map<DoctorDto>(doctor);
        }

        public IEnumerable<DoctorDto> GetAll()
        {
            var doctors = _doctorRepository.GetAll();

            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }

        public DoctorDto Add(string name, string surname, Specialization specialization)
        {
            var id = Guid.NewGuid();
            var doctor = new Doctor(id, name, surname, specialization);

            _doctorRepository.Add(doctor);
            
            return _mapper.Map<DoctorDto>(doctor);
        }

        public void Update(string name, string surname, Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}