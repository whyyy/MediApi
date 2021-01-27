using FakeItEasy;
using Medi.WebApi.Controllers;
using Medi.WebApi.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace MediAPITests
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
    }
}