using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class BookmarkBusinessService
    {
        private readonly BookmarkService _bookmarkService;

        public BookmarkBusinessService(BookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        // Brug af databasefunktionen add_bookmark
        public async Task<bool> AddBookmarkUsingFunctionAsync(int userId, string itemType, string itemId, string annotation)
        {
            return await _bookmarkService.AddBookmarkUsingFunctionAsync(userId, itemType, itemId, annotation);
        }

        // CRUD: Tilføj et bogmærke direkte
        public async Task<bool> AddBookmarkAsync(int userId, string itemType, string itemId, string annotation)
        {
            return await _bookmarkService.AddBookmarkAsync(userId, itemType, itemId, annotation);
        }

        // CRUD: Hent bogmærker efter bruger-ID
        public async Task<object> GetBookmarksByUserIdAsync(int userId)
        {
            return await _bookmarkService.GetBookmarksByUserIdAsync(userId);
        }

        // CRUD: Opdater et bogmærke
        public async Task<bool> UpdateBookmarkAsync(int bookmarkId, string newAnnotation)
        {
            return await _bookmarkService.UpdateBookmarkAsync(bookmarkId, newAnnotation);
        }

        // CRUD: Slet et bogmærke
        public async Task<bool> DeleteBookmarkAsync(int bookmarkId)
        {
            return await _bookmarkService.DeleteBookmarkAsync(bookmarkId);
        }
    }
}
