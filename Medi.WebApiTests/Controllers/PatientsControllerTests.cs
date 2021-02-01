using System.Web.Http.Results;
using Castle.Core.Logging;
using FakeItEasy;
using NUnit.Framework;

namespace MediAPITests.Controllers
{
    [TestFixture]
    public class PatientsControllerTests
    {
        private ILogger<PatientsController> _logger;
        private IPatientService _patientService;
        private PatientController _patientController;
        
        [SetUp]
        public void Setup()
        {
            _logger = A.Fake<ILogger<PatientsController>>();
            _patientService = A.Fake<IPatientService>();
            _patientController = new PatientController(_logger, _patientService);
        }

        [Test]
        public void Should_ReturnPatientsAndOkResult_When_GetAll()
        {
            var result = _patientController.GetAll();

            A.CallTo(() => _patientService.GetAll()).MustHaveHappened();
            Assert.AreEqual(typeof(OkResult), result.GetType());
        }
    }
}