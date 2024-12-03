using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class ExactMatchService
    {
        private readonly MovieContext _dbContext;

        public ExactMatchService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Kald SQL-funktionen exact_match og få resultaterne uden DbSet
        public async Task<List<ExactMatchResult>> GetExactMatchMoviesAsync(string keyword1, string keyword2 = null)
        {
            // SQL-forespørgslen til at kalde exact_match funktionen
            var query = $"SELECT * FROM exact_match('{keyword1}', '{(keyword2 ?? string.Empty)}')";

            // Brug ExecuteSqlRawAsync til at eksekvere forespørgslen og hente resultater
            var result = await _dbContext.Set<ExactMatchResult>()
                .FromSqlRaw(query)
                .ToListAsync();

            return result;
        }
    }

    // Resultatmodel til exact_match
    public class ExactMatchResult
    {
        public string movie_id { get; set; }
        public string movie_title { get; set; }
    }
}
