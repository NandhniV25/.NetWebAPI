using AutoMapper;
using first.DTOs.Fight;
using first.DTOs.Skill;

namespace first.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Characters,GetCharacterDto>();
            CreateMap<AddCharacterDto,Characters>();
            CreateMap<UpdateCharacterDto,Characters>();

            CreateMap<Weapon, GetWeaponDto>();

            CreateMap<Skill, GetSkillDto>();

            CreateMap<Characters, HighScoreDto>();

        }
    }
}
