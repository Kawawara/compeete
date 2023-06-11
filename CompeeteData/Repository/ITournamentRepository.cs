using CompeeteData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeeteData.Repository
{
    public interface ITournamentRepository
    {
        Task<List<Tournament>> GetAllAsync();
        Task<Tournament> GetTournamentById(int id);
        Task<List<Tournament>> GetTournamentsByEventId(int id);
        Task UpdateTournamentAsync(Tournament tournament);
        Task DeleteTournamentAsync(Tournament tournament);
        Task CreateNewTournamentAsync(Tournament tournament);

    }
}
