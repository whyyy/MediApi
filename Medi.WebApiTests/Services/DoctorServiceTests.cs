using System;
using System.Collections.Generic;
using AutoMapper;
using FakeItEasy;
using Medi.Core.Domain;
using Medi.Core.Repositories;
using Medi.WebApi.DTO;
using Medi.WebApi.Services;
using NUnit.Framework;

namespace MediAPITests.Services
{
    [TestFixture]
    public class DoctorServiceTests
    {
        private IDoctorRepository _doctorRepository;
        private IMapper _mapper;
        private IDoctorService _doctorService;

        [SetUp]
        public void Setup()
        {
            _doctorRepository = A.Fake<IDoctorRepository>();
            _mapper = A.Fake<IMapper>();
            
            _doctorService = new DoctorService(_doctorRepository, _mapper);
        }

        [Test]
        public void Should_CreateDoctorDto_When_Add()
        {
            var doctor = A.Fake<Doctor>(); 
            _doctorService.Add(doctor.Name, doctor.Surname, doctor.Specialization);

            A.CallTo(() => _doctorRepository.Add(A<Doctor>._)).MustHaveHappened();
            A.CallTo(() => _mapper.Map<DoctorDto>(A<Doctor>._)).MustHaveHappened();
        }

        [Test]
        public void Should_ReturnDoctorDto_When_Get()
        {
            var guid = Guid.NewGuid();
            _doctorService.Get(guid);

            A.CallTo(() => _doctorRepository.Get(guid)).MustHaveHappened();
            A.CallTo(() => _mapper.Map<DoctorDto>(A<Doctor>._)).MustHaveHappened();
        }

        [Test]
        public void Should_ReturnDoctorDtoCollection_When_GetAll()
        {
            _doctorService.GetAll();

            A.CallTo(() => _doctorRepository.GetAll()).MustHaveHappened();
            A.CallTo(() => _mapper.Map<IEnumerable<DoctorDto>>(A<IEnumerable<Doctor>>._)).MustHaveHappened();
        }

        [Test]
        public void Should_CallUpdate_When_Update()
        {
            _doctorService.Update(Guid.Empty, "NewName", "NewSurname", Specialization.FamilyDoctor);
            
            A.CallTo(() => _doctorRepository.Update(A<Doctor>._)).MustHaveHappened();
        }

        [Test]
        public void Should_CallDelete_When_Delete()
        {
            _doctorService.Delete(Guid.Empty);
            
            A.CallTo(() => _doctorRepository.Delete(A<Guid>._)).MustHaveHappened();
        }
    }
}