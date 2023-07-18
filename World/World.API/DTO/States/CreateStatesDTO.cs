using System.ComponentModel.DataAnnotations;

namespace World.API.DTO.States
{
    public class CreateStatesDTO
    {
        public string Name { get; set; }
        public double Population { get; set; }
        public int CountryId { get; set; }
    }
}
