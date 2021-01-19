using MediAPI.Helpers;

namespace MediAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public Specialization Specialization { get; set; }
    }
}