using Microsoft.EntityFrameworkCore;
using MovieApp.DataLayer.Models;
using System.Security.Cryptography;
using System.Text;

namespace MovieApp.DataLayer.Services
{
    public class UserService
    {
        private readonly MovieContext _dbContext;

        public UserService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _dbContext.users.FindAsync(userId);
        }

        public async Task<bool> AddUserAsync(int userId, string username, string email, string password, string? role = null, string? salt = null)
        {
            try
            {
                // Generer salt, hvis det ikke er angivet
                if (string.IsNullOrEmpty(salt))
                {
                    salt = GenerateSalt();
                }

                // Hash passwordet med salt
                var hashedPassword = HashPassword(password, salt);

                await _dbContext.Database.ExecuteSqlRawAsync(
                    "INSERT INTO users (user_id, username, email, password, role, salt) VALUES ({0}, {1}, {2}, {3}, {4}, {5})",
                    userId, username, email, hashedPassword, role, salt
                );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(int userId, string username, string email, string password, string? role = null, string? salt = null)
        {
            try
            {
                // Generer salt, hvis det ikke er angivet
                if (string.IsNullOrEmpty(salt))
                {
                    salt = GenerateSalt();
                }

                // Hash passwordet med salt
                var hashedPassword = HashPassword(password, salt);

                await _dbContext.Database.ExecuteSqlRawAsync(
                    "UPDATE users SET username = {0}, email = {1}, password = {2}, role = {3}, salt = {4} WHERE user_id = {5}",
                    username, email, hashedPassword, role, salt, userId
                );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                var user = await _dbContext.users.FindAsync(userId);
                if (user == null) return false;

                _dbContext.users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Function Calls
        public async Task<bool> AddUserViaFunctionAsync(string username, string email, string password)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync(
                    "SELECT add_user({0}, {1}, {2})",
                    username, email, password
                );
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateSalt()
        {
            var buffer = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }
            return Convert.ToBase64String(buffer);
        }


        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combined = Encoding.UTF8.GetBytes(password + salt);
                return Convert.ToBase64String(sha256.ComputeHash(combined));
            }
        }
    }
}
