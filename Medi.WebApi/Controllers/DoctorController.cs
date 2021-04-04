using System;
using Medi.Infrastructure.Endpoints;
using Medi.WebApi.DTO;
using Medi.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Medi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        private readonly IDoctorService _doctorService;

        public DoctorController(ILogger<DoctorController> logger, IDoctorService doctorService)
        {
            _logger = logger;
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var doctors = _doctorService.GetAll();

            return Ok(doctors);
        }

        [HttpGet("id")]
        public IActionResult Get(Guid id)
        {
            var doctor = _doctorService.Get(id);

            if (doctor is null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DoctorDto doctorDto)
        {
            doctorDto = _doctorService.Add(doctorDto.Name, doctorDto.Surname, doctorDto.Specialization);

            return Created(DoctorControllerEndpoints.Post(doctorDto.Id), doctorDto);
        }

        [HttpPut("id")]
        public IActionResult Put(Guid id,[FromBody] DoctorDto doctorDto)
        {
            _doctorService.Update(id, doctorDto.Name, doctorDto.Surname, doctorDto.Specialization);
            
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult Delete(Guid id)
        {
            _doctorService.Delete(id);

            return NoContent();
        }
    }
}