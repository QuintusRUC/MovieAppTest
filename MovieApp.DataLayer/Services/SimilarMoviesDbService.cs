using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class SimilarMoviesDbService
    {
        private readonly MovieContext _dbContext;

        public SimilarMoviesDbService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Kald SQL-funktionen similar_movies
        public async Task<List<SimilarMoviesResult>> GetSimilarMoviesAsync(string movieTitle)
        {
            var query = $"SELECT * FROM similar_movies('{movieTitle}')";
            return await _dbContext.Set<SimilarMoviesResult>().FromSqlRaw(query).ToListAsync();
        }
    }

    // Model for de returnerede resultater
    public class SimilarMoviesResult
    {
        public string MovieName { get; set; }
    }
}
