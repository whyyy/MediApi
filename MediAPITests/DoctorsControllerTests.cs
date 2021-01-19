using System.Collections.Generic;
using FakeItEasy;
using MediAPI.Controllers;
using MediAPI.Helpers;
using MediAPI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MediAPITests
{
    [TestClass]
    public class DoctorsControllerTests
    {
        private ILogger<DoctorsController> _logger;
        private DoctorsController _doctorsController;
        private List<Doctor> _doctors;
        
        [SetUp]
        public void Setup()
        {
            _logger = A.Fake<ILogger<DoctorsController>>();
            _doctors = GetTestDoctors();
            _doctorsController = new DoctorsController(_logger);
        }
        
        [Test]
        public void Should_ReturnDoctor_When_Get()
        {
            var result = _doctorsController.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        private static List<Doctor> GetTestDoctors()
        {
            var doctors = new List<Doctor>();
            doctors.Add(new Doctor{Id = 1, Name = "Name1", Surname = "Surname1", Specialization = Specialization.Trainee});
            doctors.Add(new Doctor{Id = 2, Name = "Name2", Surname = "Surname2", Specialization = Specialization.Gynecology});
            doctors.Add(new Doctor{Id = 3, Name = "Name3", Surname = "Surname3", Specialization = Specialization.Pediatrics});
            doctors.Add(new Doctor{Id = 4, Name = "Name4", Surname = "Surname4", Specialization = Specialization.Radiology});
            doctors.Add(new Doctor{Id = 5, Name = "Name5", Surname = "Surname5", Specialization = Specialization.Surgery});

            return doctors;
        }
    }
}