using AutoMapper;
using Medi.Core.Domain;
using MediAPI.DTO;

namespace MediAPI.Mappers
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