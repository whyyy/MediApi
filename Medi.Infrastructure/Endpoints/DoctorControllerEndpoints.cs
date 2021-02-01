namespace Medi.Infrastructure.Endpoints
{
    public static class DoctorControllerEndpoints
    {
        public static string Post(string id)
        {
            return $"api/doctors/{id}";
        }
    }
}