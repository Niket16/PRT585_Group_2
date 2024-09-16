using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IEventService
    {
        Task<EventModel?> GetById(int EventId);

        Task<List<EventModel>> GetAll();

        Task<int> CreateEvent(EventModel Event);
        Task UpdateEvent(EventModel Event);
        Task DeleteEvent(int EventId);
    }
}
