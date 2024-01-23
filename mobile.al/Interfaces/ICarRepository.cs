using mobile.al.Models;

namespace mobile.al.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAll();
        Task<Car> GetByIdAsync(int Id);
        Task<Car> GetByIdAsyncNoTracking(int Id);
        Task<IEnumerable<Car>> GetCarByCity(string City);
        bool Add(Car car);
        bool Update(Car car);
        bool Delete(Car car);
        bool Save();
    }
}
