using CompeeteData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeeteData.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly CompeeteDBContext _context;

        public EventRepository(CompeeteDBContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllAsync()
        {
            var events = await _context.Events.Include(c => c.User).ToListAsync();
            return events;
        }
        public async Task<List<Event>> GetNextEventsAsync()
        {
            var events = await _context.Events.Where(c => c.End > DateTime.Now).Include(c => c.User).OrderBy(c => c.Start).ToListAsync();
            return events;
        }
        public async Task<List<Event>> GetPastEventsAsync()
        {
            var events = await _context.Events.Where(c => c.Start <= DateTime.Now).Include(c => c.User).OrderByDescending(c => c.Start).ToListAsync();
            return events;
        }
        public async Task<Event> GetEventById(int id)
        {
            var eventt = await _context.Events.FindAsync(id);
            return eventt;
        }

        public async Task UpdateEventAsync(Event tour)
        {
            if (tour == null | tour.Id <= 0)
            {
                throw new ArgumentException(nameof(tour));
            }
            _context.Events.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(Event e)
        {
            if (e == null | e.Id <= 0)
            {
                throw new ArgumentException(nameof(e));
            }
            _context.Events.Remove(e);
            await _context.SaveChangesAsync();
        }

        public async Task<Event> CreateNewEventAsync(Event tour)
        {
            if (tour == null)
            {
                throw new ArgumentException(nameof(tour));
            }
            await _context.Events.AddAsync(tour);
            await _context.SaveChangesAsync();
            return tour;
        }
    }
}
