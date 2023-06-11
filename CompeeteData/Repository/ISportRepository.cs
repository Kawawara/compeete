using CompeeteData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeeteData.Repository
{
    public interface ISportRepository
    {
        Task<List<Sport>> GetAllAsync();
        Task<Sport> GetSportByName(string name);
        Task UpdateSportAsync(Sport tour);
        Task DeleteSportAsync(Sport tour);
        Task CreateNewSportAsync(Sport tour);
    }
}
