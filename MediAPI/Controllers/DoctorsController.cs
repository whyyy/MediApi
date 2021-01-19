using MediAPI.Helpers;
using MediAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> _logger;

        public DoctorsController(ILogger<DoctorsController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            return new Doctor
            {
                Id = id,
                Name = "Martha",
                Surname = "Pro",
                Specialization = Specialization.Trainee
            };
        }
    }
}