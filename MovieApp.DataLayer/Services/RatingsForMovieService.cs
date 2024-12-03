using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class RatingsForMovieService
    {
        private readonly MovieContext _dbContext;

        public RatingsForMovieService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Metode til at hente ratings baseret på film-ID (tconst)
        public async Task<List<RatingsForMovieResult>> GetRatingsForMovieAsync(string tconst)
        {
            // Brug SQL-forespørgslen fra calculate_ratings_for_movie funktionen
            return await _dbContext.Set<RatingsForMovieResult>()
                .FromSqlRaw("SELECT * FROM calculate_ratings_for_movie({0})", tconst)
                .ToListAsync();
        }
    }

    public class RatingsForMovieResult
    {
        public string nconst { get; set; }   // Skuespillerens ID (nconst)
        public string primaryname { get; set; }   // Skuespillerens navn
        public decimal name_rating { get; set; }   // Skuespillerens vægtede rating
    }


}
