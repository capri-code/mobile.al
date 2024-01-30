using Microsoft.EntityFrameworkCore;
using mobile.al.Data;
using mobile.al.Models;
using mobile.al.Interfaces;

namespace mobile.al.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public DashboardRepository(AppDbContext context, IHttpContextAccessor httpContextAccesor)
        {
            _context = context;
            _httpContextAccesor = httpContextAccesor;
        }
        public async Task<List<Car>> GetAllUserCars()
        {
            var curUser = _httpContextAccesor.HttpContext?.User.GetUserId();
            var userCars = _context.Cars.Where(r => r.AppUser.Id == curUser);
            return userCars.ToList();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
