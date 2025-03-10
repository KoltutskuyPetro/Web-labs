using AutoMapper;
using Cars.Api.Models.Domain;
using Cars.Api.Models.DTO;

namespace Cars.Api.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<AddCarRequestDto, Car>().ReverseMap();
            CreateMap<UpdateCarRequestDto, Car>().ReverseMap();
        }
    }
}

