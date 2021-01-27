using Medi.Core.Domain;

namespace MediAPI.DTO
{
    public class DoctorDto
    {
        public string Id { get; set; }

        public string  Name { get; set; }
        
        public string  Surname { get; set; }

        public Specialization Specialization { get; set; }
    }
}