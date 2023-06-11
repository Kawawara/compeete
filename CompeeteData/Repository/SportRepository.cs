using CompeeteData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeeteData.Repository
{
    public class SportRepository : ISportRepository
    {
        private readonly CompeeteDBContext _context;

        public SportRepository(CompeeteDBContext context)
        {
            _context = context;
        }

        public async Task<List<Sport>> GetAllAsync()
        {
            var sports = await _context.Sports.ToListAsync();
            return sports;
        }
        public async Task<Sport> GetSportByName(string name)
        {
            var sport = await _context.Sports.Where(s => s.Name == name).FirstOrDefaultAsync();
            return sport;
        }
        public async Task UpdateSportAsync(Sport tour)
        {
            if (tour == null | tour.Id <= 0)
            {
                throw new ArgumentException(nameof(tour));
            }
            _context.Sports.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSportAsync(Sport tour)
        {
            if (tour == null | tour.Id <= 0)
            {
                throw new ArgumentException(nameof(tour));
            }
            _context.Sports.Remove(tour);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNewSportAsync(Sport tour)
        {
            if (tour == null)
            {
                throw new ArgumentException(nameof(tour));
            }
            await _context.Sports.AddAsync(tour);
            await _context.SaveChangesAsync();
        }
    }
}
