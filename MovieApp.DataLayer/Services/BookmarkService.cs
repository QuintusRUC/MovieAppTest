using Microsoft.EntityFrameworkCore;
using MovieApp.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class BookmarkService
    {
        private readonly MovieContext _dbContext;

        public BookmarkService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add bookmark using the add_bookmark database function
        public async Task<bool> AddBookmarkUsingFunctionAsync(int userId, string itemType, string itemId, string annotation)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync(
                    "SELECT add_bookmark({0}, {1}, {2}, {3})",
                    userId, itemType, itemId, annotation
                );
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Add a bookmark (CRUD operation)
        public async Task<bool> AddBookmarkAsync(int userId, string itemType, string itemId, string annotation)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync(
                    "INSERT INTO bookmarks (user_id, item_type, item_id, annotation) VALUES ({0}, {1}, {2}, {3})",
                    userId, itemType, itemId, annotation
                );
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Get bookmarks by user ID
        public async Task<List<Bookmark>> GetBookmarksByUserIdAsync(int userId)
        {
            try
            {
                var bookmarks = await _dbContext.bookmarks
                    .FromSqlRaw("SELECT * FROM get_bookmarks({0})", userId)
                    .ToListAsync();
                return bookmarks;
            }
            catch
            {
                return null;
            }
        }

        // Update a bookmark
        public async Task<bool> UpdateBookmarkAsync(int bookmarkId, string newAnnotation)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync(
                    "UPDATE bookmarks SET annotation = {0} WHERE bookmark_id = {1}",
                    newAnnotation, bookmarkId
                );
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Delete a bookmark
        public async Task<bool> DeleteBookmarkAsync(int bookmarkId)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync(
                    "DELETE FROM bookmarks WHERE bookmark_id = {0}",
                    bookmarkId
                );
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
