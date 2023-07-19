using System.ComponentModel.DataAnnotations;

namespace World.Web.DTO
{
    public class StateDTO
    {
        public string Name { get; set; }
        public double Population { get; set; }
        public int CountryId { get; set; }
    }
}
