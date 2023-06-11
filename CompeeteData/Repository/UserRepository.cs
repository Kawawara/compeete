using CompeeteData.Models;
using Microsoft.EntityFrameworkCore;

namespace CompeeteData.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly CompeeteDBContext _context;

        public UserRepository(CompeeteDBContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.Include(C => C.Tournaments).FirstOrDefaultAsync(c => c.Id == id);
            return user;
        }
        public async Task<User> GetUserByEmail(string mail)
        {
            var user = await _context.Users.Include(C => C.Tournaments).FirstOrDefaultAsync(c => c.Email == mail);
            return user;
        }
        public async Task UpdateUserAsync(User user)
        {
            if (user == null | user.Id <= 0)
            {
                throw new ArgumentException(nameof(user));
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            if (user == null | user.Id <= 0)
            {
                throw new ArgumentException(nameof(user));
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNewUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentException(nameof(user));
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
