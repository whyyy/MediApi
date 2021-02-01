using FakeItEasy;
using Medi.WebApi.Controllers;
using Medi.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace MediAPITests.Controllers
{
    [TestFixture]
    public class PatientsControllerTests
    {
        private ILogger<PatientController> _logger;
        private IPatientService _patientService;
        private PatientController _patientController;
        
        [SetUp]
        public void Setup()
        {
            _logger = A.Fake<ILogger<PatientController>>();
            _patientService = A.Fake<IPatientService>();
            _patientController = new PatientController(_logger, _patientService);
        }

        [Test]
        public void Should_ReturnPatientsAndOkResult_When_GetAll()
        {
            var result = _patientController.Get();

            A.CallTo(() => _patientService.GetAll()).MustHaveHappened();
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }
    }
}