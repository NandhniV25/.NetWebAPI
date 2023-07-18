using System.ComponentModel.DataAnnotations;

namespace World.Web.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string CountryCode { get; set; }
    }
}
