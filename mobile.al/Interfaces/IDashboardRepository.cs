using mobile.al.Models;

namespace mobile.al.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Car>> GetAllUserCars();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
