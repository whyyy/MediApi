using System;
using FakeItEasy;
using Medi.Core.Domain;
using Medi.WebApi.Controllers;
using Medi.WebApi.DTO;
using Medi.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MediAPITests.Controllers
{
    [TestClass]
    public class DoctorsControllerTests
    {
        private ILogger<DoctorController> _logger;
        private IDoctorService _doctorService;
        private DoctorController _doctorController;

        [SetUp]
        public void Setup()
        {
            _logger = A.Fake<ILogger<DoctorController>>();
            _doctorService = A.Fake<IDoctorService>();
            _doctorController = new DoctorController(_logger, _doctorService);
        }

        [Test]
        public void Should_ReturnOkResult_When_Get()
        {
            var result = _doctorController.Get();

            A.CallTo(() => _doctorService.GetAll()).MustHaveHappenedOnceExactly();
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }

        [Test]
        public void Should_AddDoctorAndReturnCreated_When_Post()
        {
            var doctorDto = A.Fake<DoctorDto>();
            doctorDto.Name = "MyName";
            doctorDto.Surname = "Surname";
            doctorDto.Specialization = Specialization.Surgery;

            var result = _doctorController.Post(doctorDto);

            A.CallTo(() => _doctorService.Add(doctorDto.Name, doctorDto.Surname, doctorDto.Specialization))
                .MustHaveHappened();
            Assert.AreEqual(typeof(CreatedResult), result.GetType());
        }

        [Test]
        public void Should_ReturnOkResultWithDoctor_When_GetById()
        {
            var doctorDto = A.Fake<DoctorDto>();
            var guid = Guid.NewGuid();
            doctorDto.Id = guid.ToString();
            doctorDto.Name = "MyName";
            doctorDto.Surname = "Surname";
            doctorDto.Specialization = Specialization.Surgery;
            A.CallTo(() => _doctorService.Get(guid)).Returns(doctorDto);

            var result = _doctorController.Get(guid);

            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }

        [Test]
        public void Should_ReturnNotFound_When_NotFoundDoctorForId()
        {
            var guid = Guid.NewGuid();
            A.CallTo(() => _doctorService.Get(guid)).Returns(null);

            var result = _doctorController.Get(guid);

            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
        }

        [Test]
        public void Should_ReturnNoContent_When_Put()
        {
            var guid = Guid.NewGuid();
            var updatedDoctorDto = A.Fake<DoctorDto>();
            updatedDoctorDto.Name = "NewName";
            updatedDoctorDto.Surname = "NewSurname";
            updatedDoctorDto.Specialization = Specialization.Radiology;

            var result = _doctorController.Put(guid, updatedDoctorDto);

            A.CallTo(() => _doctorService.Update(guid, updatedDoctorDto.Name, updatedDoctorDto.Surname,
                updatedDoctorDto.Specialization)).MustHaveHappenedOnceExactly();
            Assert.AreEqual(typeof(NoContentResult), result.GetType());
        }

        [Test]
        public void Should_ReturnNoContent_When_Delete()
        {
            var guid = Guid.NewGuid();

            var result = _doctorController.Delete(guid);

            A.CallTo(() => _doctorService.Delete(guid)).MustHaveHappenedOnceExactly();
            Assert.AreEqual(typeof(NoContentResult), result.GetType());
        }
}
}