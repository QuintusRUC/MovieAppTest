using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class RateDbService
    {
        private readonly MovieContext _dbContext;

        public RateDbService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Kald SQL-funktionen rate
        public async Task RateMovieAsync(int userId, string movieId, int rating)
        {
            var query = $"SELECT * FROM rate({userId}, '{movieId}', {rating})";
            await _dbContext.Database.ExecuteSqlRawAsync(query);
        }
    }
}
