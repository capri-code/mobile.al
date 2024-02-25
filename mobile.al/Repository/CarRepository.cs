using Microsoft.EntityFrameworkCore;
using mobile.al.Data;
using mobile.al.Interfaces;
using mobile.al.Models;

namespace mobile.al.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;
        public CarRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(Car car)
        {
            _context.Add(car);
            return Save();
        }

        public bool Delete(Car car)
        {
            _context.Remove(car);
            return Save();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars
                .Include(i => i.Address)
                .Include(i => i.Photos)
                .ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars
                .Include(i => i.Address)
                .Include(i => i.Photos)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Car> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Cars.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Car>> GetCarByCity(string city)
        {
            return await _context.Cars.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Car car)
        {
            _context.Update(car);
            return Save();
        }
    }
}
