using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IEventDal
    {
        // Getters
        EventModel? GetById(int EventId);
        List<EventModel> GetAll();

        // Actions
        int CreateEvent(EventModel Event);
        void UpdateEvent(EventModel Event);
        void DeleteEvent(int EventId);
    }
}
