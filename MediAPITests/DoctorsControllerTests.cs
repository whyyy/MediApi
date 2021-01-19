using System.Linq;
using FakeItEasy;
using MediAPI.Controllers;
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
        
        [SetUp]
        public void Setup()
        {
            _logger = A.Fake<ILogger<DoctorsController>>();
            _doctorsController = new DoctorsController(_logger);
        }
        
        [Test]
        public void Should_ReturnDoctor_When_GetWithId()
        {
            var result = _doctorsController.Get(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Martha", result.Name);
        }

        [Test]
        public void Should_ReturnDoctors_When_Get()
        {
            var result = _doctorsController.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }
    }
}