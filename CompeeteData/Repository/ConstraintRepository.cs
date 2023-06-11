using CompeeteData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeeteData.Repository
{
    public class ConstraintRepository : IConstraintRepository
    {
        private readonly CompeeteDBContext _context;

        public ConstraintRepository(CompeeteDBContext context)
        {
            _context = context;
        }

        public async Task<List<Constraint>> GetAllAsync()
        {
            var sports = await _context.Constraints.ToListAsync();
            return sports;
        }

        public async Task UpdateConstraintAsync(Constraint tour)
        {
            if (tour == null | tour.Id <= 0)
            {
                throw new ArgumentException(nameof(tour));
            }
            _context.Constraints.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConstraintAsync(Constraint tour)
        {
            if (tour == null | tour.Id <= 0)
            {
                throw new ArgumentException(nameof(tour));
            }
            _context.Constraints.Remove(tour);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNewConstraintAsync(Constraint tour)
        {
            if (tour == null)
            {
                throw new ArgumentException(nameof(tour));
            }
            await _context.Constraints.AddAsync(tour);
            await _context.SaveChangesAsync();
        }
    }
}
