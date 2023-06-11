using CompeeteData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompeeteData.Repository
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllAsync();
        Task<List<Event>> GetNextEventsAsync();
        Task<List<Event>> GetPastEventsAsync();
        Task<Event> GetEventById(int id);
        Task UpdateEventAsync(Event eventt);
        Task DeleteEventAsync(Event eventt);
        Task<Event> CreateNewEventAsync(Event eventt);
    }
}
