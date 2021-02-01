using AutoMapper;
using Medi.Core.Domain;
using Medi.WebApi.DTO;

namespace Medi.WebApi.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize() 
        => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Doctor, DoctorDto>();
        })
            .CreateMapper();
    }
}