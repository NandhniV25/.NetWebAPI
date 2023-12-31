﻿using System.ComponentModel.DataAnnotations;

namespace World.API.Models
{
    public class Country
    {
        //only Property can be defined in the models
        //no methods

        [Key] // explicit primary key 
        public int Id { get; set; }

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
