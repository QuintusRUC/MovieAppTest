using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Models;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class UserBusinessService
    {
        private readonly UserService _userService;

        public UserBusinessService(UserService userService)
        {
            _userService = userService;
        }

        // Get all users
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        // Get a user by ID
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _userService.GetUserByIdAsync(userId);
        }

        // Add a user
        public async Task<bool> AddUserAsync(int userId, string username, string email, string password, string role, string salt)
        {
            return await _userService.AddUserAsync(userId, username, email, password, role, salt);
        }

        // Update a user
        public async Task<bool> UpdateUserAsync(int userId, string username, string email, string password, string role, string salt)
        {
            return await _userService.UpdateUserAsync(userId, username, email, password, role, salt);
        }

        // Delete a user
        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _userService.DeleteUserAsync(userId);
        }

        // Add user via database function
        public async Task<bool> AddUserViaFunctionAsync(string username, string email, string password)
        {
            return await _userService.AddUserViaFunctionAsync(username, email, password);
        }
    }
}
