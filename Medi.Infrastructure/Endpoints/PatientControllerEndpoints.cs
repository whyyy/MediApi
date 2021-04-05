namespace Medi.Infrastructure.Endpoints
{
    public static class PatientControllerEndpoints
    {
        public static string Post(string id)
        {
            return $"api/patient/{id}";
        }
    }
}