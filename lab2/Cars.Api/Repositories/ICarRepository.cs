using System;
using Cars.Api.Models.Domain;

namespace Cars.Api.Repositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllAsync();

        Task<Car?> GetByIdAsync(Guid id);

        Task<Car> CreateAsync(Car region);

        Task<Car?> UpdateAsync(Guid id, Car region);

        Task<Car?> DeleteAsync(Guid id);
    }
}

