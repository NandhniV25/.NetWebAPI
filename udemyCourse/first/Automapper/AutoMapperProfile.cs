using AutoMapper;

namespace first.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Characters,GetCharacterDto>();
            CreateMap<AddCharacterDto,Characters>();
            CreateMap<UpdateCharacterDto,Characters>();
        }
    }
}
