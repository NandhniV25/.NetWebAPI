using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.DTO;
using NotesAPI.Repository.IRepository;

namespace NotesAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        //Dependency Injection
        private readonly INotesRepository _notesRepository;

        //Mapper Injection
        private readonly IMapper _mapper;

        //cmd => gives info. application Track
        private readonly ILogger<NotesController> _logger;

        //Constructor
        public NotesController(INotesRepository notesRepository, IMapper mapper, ILogger<NotesController> logger)
        {
            _notesRepository = notesRepository;
            _mapper = mapper;
            _logger = logger;
        }

        //HttpMethods
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NotesDto>>> GetAll()
        {
            var notes = await _notesRepository.GetAll();
            if (notes == null)
            {
                return NoContent();
            }
            var notesDto = _mapper.Map<List<NotesDto>>(notes);
            return Ok(notesDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<NotesDto>> GetById(int id)
        {
            var notes = await _notesRepository.GetById(id);
            if (notes == null)
            {
                _logger.LogError($"Error while try to get record id : {id}");
                return NoContent();
            }
            var notesDto = _mapper.Map<NotesDto>(notes);
            return Ok(notesDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateNotesDTO>> Create([FromBody] CreateNotesDTO notesDto)
        {
            var notes = _mapper.Map<Notes>(notesDto);
            await _notesRepository.Create(notes);
            return CreatedAtAction("GetById", new { id = notes.Id }, notes);    
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Notes>> Update(int id,[FromBody] UpdateNotesDTO uNotesDto)
        {
            if (uNotesDto == null || id != uNotesDto.Id)
            {
                return BadRequest();
            }
            var notes = _mapper.Map<Notes>(uNotesDto);
            await _notesRepository.Update(notes);
            return NoContent();    
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var notes = await _notesRepository.GetById(id);
            if (notes == null)
            {
                return NotFound();
            }
            await _notesRepository.Delete(notes);
            return NoContent();
        }
    }
}
