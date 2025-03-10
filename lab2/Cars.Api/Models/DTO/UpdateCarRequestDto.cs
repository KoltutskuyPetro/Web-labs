using System;
namespace Cars.Api.Models.DTO
{
	public class UpdateCarRequestDto
	{
        public string Name { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double Price { get; set; }
    }
}


