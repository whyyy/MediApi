using System;
using System.Collections.Generic;
using AutoMapper;
using Medi.Core.Domain;
using Medi.Core.Repositories;
using Medi.WebApi.DTO;

namespace Medi.WebApi.Services
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository,
                              IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public IEnumerable<PatientDto> GetAll()
        {
            var patients = _patientRepository.GetAll();

            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }
        
        public PatientDto Add(string name, 
                              string surname, 
                              string occupation,
                              string phoneNumber,
                              DateTime dateOfBirth,
                              DateTime firstDayInHospital)
        {
            var id = Guid.NewGuid();
            var doctor = new Patient(id, 
                                     name, 
                                     surname, 
                                     occupation, 
                                     phoneNumber, 
                                     dateOfBirth, 
                                     firstDayInHospital);

            _patientRepository.Add(doctor);
            
            return _mapper.Map<PatientDto>(doctor);
        }
    }
}