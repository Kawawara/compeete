using CompeeteData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeeteData.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly CompeeteDBContext _context;

        public ResultRepository(CompeeteDBContext context)
        {
            _context = context;
        }

        public async Task<List<Result>> GetAllAsync()
        {
            var results = await _context.Results.ToListAsync();
            return results;
        }

        public async Task<List<Result>> GetResultsByUserId(int id)
        {
            var result = await _context.Results.Where(c => c.User.Id == id).Include(c => c.Tournament).ToListAsync();
            return result;
        }
        public async Task<List<Result>> GetResultsByTournamentId(int id)
        {
            var result = await _context.Results.Where(c => c.Tournament.Id == id).Include(c => c.User).ToListAsync();
            return result;
        }

        public async Task UpdateResultAsync(Result tour)
        {
            if (tour == null | tour.Id <= 0)
            {
                throw new ArgumentException(nameof(tour));
            }
            _context.Results.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteResultAsync(Result tour)
        {
            if (tour == null | tour.Id <= 0)
            {
                throw new ArgumentException(nameof(tour));
            }
            _context.Results.Remove(tour);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNewResultAsync(Result tour)
        {
            if (tour == null)
            {
                throw new ArgumentException(nameof(tour));
            }
            await _context.Results.AddAsync(tour);
            await _context.SaveChangesAsync();
        }
    }
}
