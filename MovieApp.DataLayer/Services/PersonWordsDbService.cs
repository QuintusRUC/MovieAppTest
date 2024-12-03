using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class PersonWordsDbService
    {
        private readonly MovieContext _dbContext;

        public PersonWordsDbService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Kald SQL-funktionen person_words
        public async Task<List<PersonWordsResult>> GetPersonWordsAsync(string nconst, int maxLength)
        {
            var query = $"SELECT * FROM person_words('{nconst}', {maxLength})";
            return await _dbContext.Set<PersonWordsResult>().FromSqlRaw(query).ToListAsync();
        }
    }

    // Model for de returnerede resultater
    public class PersonWordsResult
    {
        public string word { get; set; }
        public int frequency { get; set; }
    }
}
