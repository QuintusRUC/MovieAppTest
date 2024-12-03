using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace MovieApp.DataLayer.Services
{
    public class StructuredStringSearchService
    {
        private readonly MovieContext _dbContext;

        public StructuredStringSearchService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Async method to execute the raw SQL query and get the result
        public async Task<List<StructuredStringSearchResult>> SearchAsync(string titleOfMovie, string plotDesc, string characterName, string actorName)
        {
            var query = "SELECT * FROM structured_string_search(@titleOfMovie, @plotDesc, @characterName, @actorName);";

            // Execute the raw SQL query using FromSqlRaw and manually map the result to StructuredStringSearchResult
            return await _dbContext.StructuredStringSearchResult
                .FromSqlRaw(query,
                    new NpgsqlParameter("@titleOfMovie", titleOfMovie ?? (object)DBNull.Value),
                    new NpgsqlParameter("@plotDesc", plotDesc ?? (object)DBNull.Value),
                    new NpgsqlParameter("@characterName", characterName ?? (object)DBNull.Value),
                    new NpgsqlParameter("@actorName", actorName ?? (object)DBNull.Value))
                .AsNoTracking() // Use AsNoTracking for better performance if no updates are done
                .ToListAsync();
        }
    }

    public class StructuredStringSearchResult
    {
        public string movie_id { get; set; }
        public string movie_title { get; set; }
    }
}

