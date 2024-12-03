using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class WordToWordService
    {
        private readonly MovieContext _dbContext;

        public WordToWordService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Model til resultater
        public class WordToWordResult
        {
            public int Id { get; set; }
            public string Word { get; set; }
            public int Frequency { get; set; }
        }

        // Metode til at hente data
        public virtual async Task<List<WordToWordResult>> GetWordsAsync(string keyword)
        {
            var query = "SELECT * FROM word_to_word(@keyword)";
            return await _dbContext.Set<WordToWordResult>()
                .FromSqlRaw(query, new Npgsql.NpgsqlParameter("@keyword", keyword))
                .ToListAsync();
        }
    }
}
