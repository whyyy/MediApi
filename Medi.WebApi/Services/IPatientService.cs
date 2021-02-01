using Microsoft.AspNetCore.Mvc;

namespace Medi.WebApi.Services
{
    public interface IPatientService
    {
        ActionResult GetAll();
    }
}