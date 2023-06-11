using CompeeteData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeeteData.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly CompeeteDBContext _context;

        public TournamentRepository(CompeeteDBContext context)
        {
            _context = context;
        }

        public async Task<List<Tournament>> GetAllAsync()
        {
            var tournaments = await _context.Tournaments.Include(c => c.Sport).Include(c => c.Constraint).ToListAsync();
            return tournaments;
        }
        public async Task<Tournament> GetTournamentById(int id)
        {
            var tournaments = await _context.Tournaments.Where(c => c.Id == id).Include(c => c.Users).Include(c => c.Sport).Include(c => c.Constraint).FirstOrDefaultAsync();
            return tournaments;
        }
        public async Task<List<Tournament>> GetTournamentsByEventId(int id)
        {
            var tournaments = await _context.Tournaments.Where(c => c.Event.Id == id).Include(c => c.Sport).Include(c => c.Constraint).ToListAsync(); ;
            return tournaments;
        }
        public async Task UpdateTournamentAsync(Tournament tour)
        {
            if (tour == null | tour.Id <= 0)
            {
                throw new ArgumentException(nameof(tour));
            }
            _context.Tournaments.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTournamentAsync(Tournament tour)
        {
            if (tour == null | tour.Id <= 0)
            {
                throw new ArgumentException(nameof(tour));
            }
            _context.Tournaments.Remove(tour);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNewTournamentAsync(Tournament tour)
        {
            if (tour == null)
            {
                throw new ArgumentException(nameof(tour));
            }
            await _context.Tournaments.AddAsync(tour);
            await _context.SaveChangesAsync();
        }

    }
}
