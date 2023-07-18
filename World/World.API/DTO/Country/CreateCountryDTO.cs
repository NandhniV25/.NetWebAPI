using System.ComponentModel.DataAnnotations;

namespace World.API.DTO.Country
{
    public class CreateCountryDTO
    {
        //model la direct ah expose pannama dto use panni api la access panrom
        //refactoring = change the internal structure of the code without altering the functionality
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(5)]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(10)]
        public string CountryCode { get; set; }
    }
}
