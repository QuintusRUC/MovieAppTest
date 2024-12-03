using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class BestMatchService
    {
        private readonly MovieContext _dbContext;

        public BestMatchService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BestMatchResult>> GetBestMatchAsync(string keyword1, string? keyword2 = null)
        {
            // Brug FromSqlRaw til at kalde funktionen
            return await _dbContext.Set<BestMatchResult>()
                .FromSqlRaw("SELECT * FROM best_match({0}, {1})", keyword1, keyword2)
                .ToListAsync();
        }
    }

    // Resultatmodel til at mappe resultaterne
    public class BestMatchResult
    {
        public int Ranking { get; set; } // matches "ranking"
        public string Movie_Id { get; set; } // matches "movie_id" in SQL
        public string Movie_Title { get; set; } // matches "movie_title" in SQL
    }

}
