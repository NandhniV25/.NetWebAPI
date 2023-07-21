using AutoMapper;
using NotesAPI.DTO;

namespace NotesAPI.Mapping
{
    public class MapperProfile : Profile
    {
        //Constructor
        public MapperProfile() 
        {
            CreateMap<Notes, NotesDto>().ReverseMap();
            CreateMap<Notes, CreateNotesDTO>().ReverseMap();
            CreateMap<Notes, UpdateNotesDTO>().ReverseMap();
        }

    }
}
