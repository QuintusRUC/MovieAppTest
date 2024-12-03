using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class NameRatingService
    {
        private readonly MovieContext _dbContext;

        public NameRatingService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CalculateNameRatingAsync(string nconst)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync(
                    "SELECT calculate_name_rating({0})",
                    nconst
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
