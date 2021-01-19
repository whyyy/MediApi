using System.Collections.Generic;
using System.Linq;
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

        private readonly Doctor[] _doctors = {
            new Doctor {Id = 1, Name = "Martha", Surname = "Pro", Specialization = Specialization.Trainee},
            new Doctor {Id = 2, Name = "Tom", Surname = "Doc", Specialization = Specialization.FamilyDoctor},
            new Doctor {Id = 3, Name = "James", Surname = "Sub", Specialization = Specialization.Gynecology}
        };

        public DoctorsController(ILogger<DoctorsController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            return _doctors.FirstOrDefault((d) => d.Id == id);
        }

        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            return _doctors;
        }
    }
}