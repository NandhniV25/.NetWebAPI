using first.Models;

namespace first.Services.CharacterServices
{
    public class CharacterServices : ICharacterServices
    {
        private static List<Characters> characters = new List<Characters>()
        {
            new Characters(),
            new Characters()
            {
                Id = 1,
                Name = "Vini",
                Strength = 1,
                HitPoints = 1,
                Intelligence = 1,
                Defense = 1
            }
        };
        public async Task<ServiceResponse<List<Characters>>> AddCharacter(Characters newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<Characters>>();
            characters.Add(newCharacter);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Characters>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Characters>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Characters>> GetCharactersById(int id)
        {
            var serviceResponse = new ServiceResponse<Characters>();
            var character = characters.FirstOrDefault(x => x.Id == id);
            //if (character is not null)
            //    return character;
            //throw new Exception("Character is not found");
            serviceResponse.Data = character;
            return serviceResponse;
        }
    }
}
