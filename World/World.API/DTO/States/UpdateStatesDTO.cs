﻿using System.ComponentModel.DataAnnotations;

namespace World.API.DTO.States
{
    public class UpdateStatesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }
        public int CountryId { get; set; }
    }
}
