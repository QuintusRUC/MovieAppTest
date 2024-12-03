using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class WordToWordBusinessService
    {
        private readonly WordToWordService _wordToWordService;

        public WordToWordBusinessService(WordToWordService wordToWordService)
        {
            _wordToWordService = wordToWordService;
        }

        public virtual async Task<List<WordToWordService.WordToWordResult>> GetWordToWordAsync(string keyword)
        {
            return await _wordToWordService.GetWordsAsync(keyword);
        }
    }
}
