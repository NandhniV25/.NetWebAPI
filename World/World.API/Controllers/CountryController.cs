using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using World.API.Data;
using World.API.DTO.Country;
using World.API.Models;
using World.API.Repository.IRepository;

namespace World.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        //private readonly ApplicationDbContext _dbContext; //database connection
        //It is in CountryRepository Class. dependency injection
        private readonly ICountryRepository _countryRepository;

        private readonly IMapper _mapper;//mapper injection

        private readonly ILogger<CountryController> _logger;//cmd => gives info. application Track

        //constructor
        //public CountryController(ApplicationDbContext dbContext, IMapper mapper)
        //{
        //    _dbContext = dbContext;
        //    _mapper = mapper;
        //}
        public CountryController(ICountryRepository countryRepository, IMapper mapper, ILogger<CountryController> logger)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        //methods
        [HttpGet] //fetch the record or read
        [ProducesResponseType(StatusCodes.Status204NoContent)] //undocumented mention
        [ProducesResponseType(StatusCodes.Status200OK)]//in the status, so we remove it
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetAll() //ienumerable or list and get is method name
        {
            var country = await _countryRepository.GetAll();// _dbContext.Countries.ToList();//return _dbContext.Countries.ToList()

            if (country == null)//; if we use in empty file the application will be crashed
            {
                return NoContent();
            }

            var countryDTO = _mapper.Map<List<CountryDTO>>(country);

            return Ok(countryDTO);
        }

        [HttpGet("{id:int}")]  //fetch the record or read using id
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CountryDTO>> GetById(int id)
        {
            var countries = await _countryRepository.GetById(id);//_dbContext.Countries.Find(id);//return _dbContext.Countries.Find(id);

            if (countries == null)   //-> this also we use but if no id is found,
            {                       //the application will be crashed so we use this one
                _logger.LogError($"Error while try to get record id : {id}"); 
                return NoContent();
            }

            //some functionality restricted. But no changes in the output
            var countriesDTO = _mapper.Map<CountryDTO>(countries);
            //countryDTO - Destination and countries - Source

            return Ok(countriesDTO);
        }

        [HttpPost] //creating the record
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateCountryDTO>> Create([FromBody]CreateCountryDTO countryDTO) //Country country => id display. if we get rid of id we must use DTO
        {
            var result = _countryRepository.IsRecordExists(x=> x.Name == countryDTO.Name);//_dbContext.Countries.AsQueryable().Where(x => x.Name.ToLower().Trim() == countryDTO.Name.ToLower().Trim()).Any(); //result type  boolean (T/F)
            
            if(result)
            {
                return Conflict("Country already exists in the database");
            }

            //we can't directly add the DTO into the database. so we create the country obj 
            //and assign it to the database
            //create local variable and assign the value.
            //country model

            //Country country = new Country();
            //country.Name = countryDTO.Name;
            //country.ShortName = countryDTO.ShortName;
            //country.CountryCode = countryDTO.CountryCode;

            //we simplify above hard code by using automapper. It is very efficient code
            var country = _mapper.Map<Country>(countryDTO);


            await _countryRepository.Create(country);//_dbContext.Countries.Add(country);
            //_dbContext.SaveChanges();
            return CreatedAtAction("GetById", new{id = country.Id}, country); //status code
        }

        [HttpPut("{id:int}")] //update the record
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Country>> Update(int id, [FromBody]UpdateCountryDTO ucountryDto)
        {
            if(ucountryDto == null || id != ucountryDto.Id)
            {
                return BadRequest();
            }

            //var countryFromDb = _dbContext.Countries.Find(id);

            //if (countryFromDb == null)
            //{
            //    return NotFound();
            //}

            //countryFromDb.Name = country.Name;
            //countryFromDb.ShortName = country.ShortName;
            //countryFromDb.CountryCode = country.CountryCode;

            var country = _mapper.Map<Country>(ucountryDto); //destination, source

            await _countryRepository.Update(country);//_dbContext.Countries.Update(country); //countryFromDb => country
            //_dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")] //delete the record
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var country = await _countryRepository.GetById(id);//_dbContext.Countries.Find(id);

            if (country == null)
            {
                return NotFound();
            }

            await _countryRepository.Delete(country);//_dbContext.Countries.Remove(country);
            //_dbContext.SaveChanges();
            return NoContent();
        }
    }
}
