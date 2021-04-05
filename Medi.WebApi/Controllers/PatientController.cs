using Medi.Infrastructure.Endpoints;
using Medi.WebApi.DTO;
using Medi.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Medi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;

        public PatientController(ILogger<PatientController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var patients = _patientService.GetAll();

            return Ok(patients);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] PatientDto patientDto)
        {
            patientDto = _patientService.Add(patientDto.Name, 
                                             patientDto.Surname, 
                                             patientDto.Occupation,
                                             patientDto.PhoneNumber,
                                             patientDto.DateOfBirth,
                                             patientDto.FirstDayInHospital);

            return Created(PatientControllerEndpoints.Post(patientDto.Id), patientDto);
        }
    }
}