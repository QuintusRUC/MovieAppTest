using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class PersonWordsDbBusinessService
    {
        private readonly PersonWordsDbService _personWordsDbService;

        public PersonWordsDbBusinessService(PersonWordsDbService personWordsDbService)
        {
            _personWordsDbService = personWordsDbService;
        }

        // Metode til at hente personens ord og hyppighed
        public async Task<List<PersonWordsResult>> GetPersonWordsAsync(string nconst, int maxLength)
        {
            return await _personWordsDbService.GetPersonWordsAsync(nconst, maxLength);
        }
    }
}
