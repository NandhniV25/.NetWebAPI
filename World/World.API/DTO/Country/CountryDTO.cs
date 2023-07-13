using System.ComponentModel.DataAnnotations;

namespace World.API.DTO.Country
{
    public class CountryDTO
    {
        //if we need not specify the validation(attribute) in the display that is httpGet method
        //if required means, we put it. It doesn't throw any error.
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string CountryCode { get; set; }
    }
}
