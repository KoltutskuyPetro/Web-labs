using System;
using Cars.Api.Data;
using Cars.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cars.Api.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarsDbContext dbContext;

        public CarRepository(CarsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Car> CreateAsync(Car region)
        {
            await dbContext.Cars.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Car?> DeleteAsync(Guid id)
        {
            var existingCar = await dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCar == null)
            {
                return null;
            }

            dbContext.Cars.Remove(existingCar);
            await dbContext.SaveChangesAsync();
            return existingCar;
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await dbContext.Cars.ToListAsync();
        }

        public async Task<Car?> GetByIdAsync(Guid id)
        {
            return await dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Car?> UpdateAsync(Guid id, Car region)
        {
            var existingCar = await dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCar == null)
            {
                return null;
            }

            existingCar.Name = region.Name;
            existingCar.Model = region.Model;
            existingCar.Year = region.Year;
            existingCar.Price = region.Price;

            await dbContext.SaveChangesAsync();
            return existingCar;
        }
    }
}

