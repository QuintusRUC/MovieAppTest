using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class FindCoplayersBusinessService
    {
        private readonly FindCoplayersService _findCoplayersService;

        public FindCoplayersBusinessService(FindCoplayersService findCoplayersService)
        {
            _findCoplayersService = findCoplayersService;
        }

        // Metode til at finde medspillere baseret på skuespillerens navn
        public async Task<List<CoplayerResult>> GetCoplayersAsync(string actorName)
        {
            return await _findCoplayersService.FindCoplayersAsync(actorName);
        }
    }
}
