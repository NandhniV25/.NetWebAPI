using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace first.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterServices _characterServices;

        public CharacterController(ICharacterServices characterServices) 
        {
            _characterServices = characterServices;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Characters>>>> Get()
        {
            return Ok(await _characterServices.GetAllCharacters());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<Characters>>> GetSingleCharacter(int id)
        {
            return Ok(await _characterServices.GetCharactersById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Characters>>>> AddCharacter(Characters newCharacter)
        { 
            return Ok(await _characterServices.AddCharacter(newCharacter));
        }
    }
}
