using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer.Services
{
    public class StructuredStringSearchBusinessService
    {
        private readonly StructuredStringSearchService _service;

        public StructuredStringSearchBusinessService(StructuredStringSearchService service)
        {
            _service = service;
        }

        public async Task<List<StructuredStringSearchResult>> SearchAsync(string titleOfMovie, string plotDesc, string characterName, string actorName)
        {
            return await _service.SearchAsync(titleOfMovie, plotDesc, characterName, actorName);
        }
    }
}
