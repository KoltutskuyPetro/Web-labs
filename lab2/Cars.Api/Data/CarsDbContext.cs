using System;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using Cars.Api.Models.Domain;

namespace Cars.Api.Data
{
	public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Car> Cars { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cars = new List<Car>()
            {
                new Car()
                {
                    Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                    Name = "Volkswagen",
                    Model = "Golf",
                    Year = 2018,
                    Price = 24000
                },
                new Car()
                {
                    Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                    Name = "Porsche",
                    Model = "Panamera",
                    Year = 2020,
                    Price = 114000
                },
                new Car()
                {
                    Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                    Name = "Alfa Romeo",
                    Model = "Gulia",
                    Year = 2021,
                    Price = 31000
                }
            };

            modelBuilder.Entity<Car>().HasData(cars);
        }
    }
}


