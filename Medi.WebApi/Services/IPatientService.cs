using System;
using System.Collections.Generic;
using Medi.WebApi.DTO;

namespace Medi.WebApi.Services
{
    public interface IPatientService
    {
        IEnumerable<PatientDto> GetAll();

        PatientDto Add(string name,
                       string surname,
                       string occupation,
                       string phoneNumber,
                       DateTime dateOfBirth,
                       DateTime firstDayInHospital);
    }
}