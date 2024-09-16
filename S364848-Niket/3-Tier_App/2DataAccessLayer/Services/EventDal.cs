using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Services
{
    public class EventDal : IEventDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public EventDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<EventModel> GetAll()
        {
            var result = _db.Event.ToList();

            var returnObject = new List<EventModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToEventModel());
            }

            return returnObject;
        }

        public EventModel? GetById(int EventId)
        {
            var result = _db.Event.SingleOrDefault(x => x.EventId == EventId);
            return result?.ToEventModel();
        }


        public int CreateEvent(EventModel Event)
        {
            var newEvent = Event.ToEvent();
            _db.Event.Add(newEvent);
            _db.SaveChanges();
            return newEvent.EventId;
        }


        public void UpdateEvent(EventModel Event)
        {
            var existingEvent = _db.Event
                .SingleOrDefault(x => x.EventId == Event.EventId);

            if (existingEvent == null)
            {
                throw new ApplicationException($"Event {Event.EventId} does not exist.");
            }
            Event.ToEvent(existingEvent);

            _db.Update(existingEvent);
            _db.SaveChanges();
        }

        public void DeleteEvent(int EventId)
        {
            var efModel = _db.Event.Find(EventId);
            _db.Event.Remove(efModel);
            _db.SaveChanges();


        }

    }

}
