using first.Models;

namespace first.Services.CharacterServices
{
    public interface ICharacterServices
    {
        Task<ServiceResponse<List<Characters>>> GetAllCharacters();
        Task<ServiceResponse<Characters>> GetCharactersById(int id);
        Task<ServiceResponse<List<Characters>>> AddCharacter(Characters newCharacter);
    }
}
