using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using World.API.Data;
using World.API.DTO.States;
using World.API.Models;
using World.API.Repository.IRepository;

namespace World.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        //Dependency Injection
        private readonly IStatesRepository _statesRepository;

        //Mapper Injection
        private readonly IMapper _mapper;

        //Constructor
        public StatesController(IStatesRepository statesRepository, IMapper mapper)
        {
            _statesRepository = statesRepository;
            _mapper = mapper;
        }

        //Methods
        [HttpGet] //Fetch all records
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StatesDTO>>> GetAll()
        {
            var state = await _statesRepository.GetAll();

            if (state == null)
            {
                return NoContent();
            }

            //some functionality restricted. But no changes in the output
            //StatesDTO - Destination and states - Source
            var stateDTO = _mapper.Map<List<StatesDTO>>(state);

            return Ok(stateDTO);
        }

        [HttpGet("{id:int}")] //fetch the specific record(id)
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StatesDTO>> GetById(int id)
        {
            var states = await _statesRepository.GetById(id);

            if (states == null)
            {
                return NoContent();
            }

            //some functionality restricted. But no changes in the output
            //StatesDTO - Destination and states - Source
            var statesDTO = _mapper.Map<StatesDTO>(states);

            return Ok(statesDTO);
        }

        [HttpPost]//Creating the record
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateStatesDTO>> Create([FromBody] CreateStatesDTO statesDTO)
        {
            var result = _statesRepository.IsRecordExists(x => x.Name == statesDTO.Name);

            if (result)
            {
                return Conflict("State already exists in the database");
            }

            var states = _mapper.Map<States>(statesDTO);

            await _statesRepository.Create(states);

            return CreatedAtAction("GetById", new { id = states.Id }, states);
        }

        [HttpPut("{id:Int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<States>> Update(int id, [FromBody] UpdateStatesDTO ustatesDto)
        {
            if (ustatesDto == null || id != ustatesDto.Id)
            {
                return BadRequest();
            }
            
            var states = _mapper.Map<States>(ustatesDto);

            await _statesRepository.Update(states);
            return NoContent();
        }

        [HttpDelete("{id:int}")]//Delete the specified record
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var states = await _statesRepository.GetById(id);

            if (states == null)
            {
                return NotFound();    
            }   
            
            await _statesRepository.Delete(states);

            return NoContent();
        }
    }
}
