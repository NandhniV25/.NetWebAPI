using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using World.API.Data;
using World.API.DTO.Country;
using World.API.Models;

namespace World.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext; //database connection

        //constructor
        public CountryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //methods
        [HttpGet] //fetch the record or read
        [ProducesResponseType(StatusCodes.Status204NoContent)] //undocumented mention
        [ProducesResponseType(StatusCodes.Status200OK)]//in the status, so we remove it
        public ActionResult<IEnumerable<Country>> GetAll() //ienumerable or list and get is method name
        {
            var country = _dbContext.Countries.ToList();//return _dbContext.Countries.ToList()
            if (country == null)//; if we use in empty file the application will be crashed
            {
                return NoContent();
            }
            return Ok(country);
        }

        [HttpGet("{id:int}")]  //fetch the record or read using id
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Country> GetById(int id)
        {
            var countries = _dbContext.Countries.Find(id);//return _dbContext.Countries.Find(id);
            if (countries == null)   //-> this also we use but if no id is found,
            {                       //the application will be crashed so we use this one
                return NoContent();
            }
            return Ok(countries);
        }

        [HttpPost] //creating the record
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<CreateCountryDTO> Create([FromBody]CreateCountryDTO countryDTO) //Country country => id display. if we get rid of id we must use DTO
        {
            var result = _dbContext.Countries.AsQueryable().Where(x => x.Name.ToLower().Trim() == countryDTO.Name.ToLower().Trim()).Any(); //result type  boolean (T/F)
            
            if(result)
            {
                return Conflict("Country already exists in the database");
            }

            //we can't directly add the DTO into the database. so we create the country obj 
            //and assign it to the database
            //create local variable and assign the value.
            //country model

            Country country = new Country();
            country.Name = countryDTO.Name;
            country.ShortName = countryDTO.ShortName;
            country.CountryCode = countryDTO.CountryCode;

            
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return CreatedAtAction("GetById", new{id = country.Id}, country); //status code
        }

        [HttpPut("{id:int}")] //update the record
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Country> Update(int id, [FromBody]Country country)
        {
            if(country == null || id != country.Id)
            {
                return BadRequest();
            }

            var countryFromDb = _dbContext.Countries.Find(id);

            if (countryFromDb == null)
            {
                return NotFound();
            }

            countryFromDb.Name = country.Name;
            countryFromDb.ShortName = country.ShortName;
            countryFromDb.CountryCode = country.CountryCode;

            _dbContext.Countries.Update(countryFromDb);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")] //delete the record
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var country = _dbContext.Countries.Find(id);

            if (country == null)
            {
                return NotFound();
            }

            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
