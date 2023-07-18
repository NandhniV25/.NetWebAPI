namespace World.API.Models
{
    public class States
    {
        //only Property can be defined in the models
        //no methods
        public int Id { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }

        //set foreign key as CountryId
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
