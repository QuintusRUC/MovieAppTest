using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class FindCoplayersService
    {
        private readonly MovieContext _dbContext;

        public FindCoplayersService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Kald SQL-funktionen find_coplayers
        public async Task<List<CoplayerResult>> FindCoplayersAsync(string actorName)
        {
            // SQL-forespørgslen til at kalde find_coplayes funktionen
            var query = $"SELECT * FROM find_coplayers('{actorName}')";

            // Brug FromSqlRaw til at hente resultaterne
            return await _dbContext.Set<CoplayerResult>()
                .FromSqlRaw(query)
                .ToListAsync();
        }
    }

    // Resultatmodel til find_coplayes
    public class CoplayerResult
    {
        public string Nconst { get; set; }
        public string PrimaryName { get; set; }
        public int Frequency { get; set; }
    }
}
