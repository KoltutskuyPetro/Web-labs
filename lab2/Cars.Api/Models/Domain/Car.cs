using System;
namespace Cars.Api.Models.Domain
{
	public class Car
	{
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double Price { get; set; }
    }
}

