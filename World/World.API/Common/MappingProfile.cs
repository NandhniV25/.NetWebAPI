using AutoMapper;
using World.API.DTO.Country;
using World.API.DTO.States;
using World.API.Models;

namespace World.API.Common
{
    public class MappingProfile : Profile
    {
        //constructor ctor and code snippets
        public MappingProfile()
        {
            //source, destination
            //CreateMap<CreateCountryDTO, Country>();
            //CreateMap<Country, CreateCountryDTO>();

            //short form of above code 
            CreateMap<Country, CreateCountryDTO>().ReverseMap();

            CreateMap<Country, CountryDTO>().ReverseMap();

            CreateMap<Country, UpdateCountryDTO>().ReverseMap();

            CreateMap<States, CreateStatesDTO>().ReverseMap();
            CreateMap<States, StatesDTO>().ReverseMap();
            CreateMap<States, UpdateStatesDTO>().ReverseMap();

        }
    }
}
