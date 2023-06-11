using CompeeteData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeeteData.Repository
{
    public interface IResultRepository
    {
        Task<List<Result>> GetAllAsync();
        Task<List<Result>> GetResultsByUserId(int id);
        Task<List<Result>> GetResultsByTournamentId(int id);
        Task UpdateResultAsync(Result res);
        Task DeleteResultAsync(Result res);
        Task CreateNewResultAsync(Result res);
    }
}
