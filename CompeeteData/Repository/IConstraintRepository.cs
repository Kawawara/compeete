using CompeeteData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeeteData.Repository
{
    public interface IConstraintRepository
    {
        Task<List<Constraint>> GetAllAsync();
        Task UpdateConstraintAsync(Constraint tour);
        Task DeleteConstraintAsync(Constraint tour);
        Task CreateNewConstraintAsync(Constraint tour);
    }
}
