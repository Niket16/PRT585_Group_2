

using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class EventService :  IEventService
    {
        private readonly IEventDal _EventDal;
        //private readonly IEventBalService _EventBalService;
        public EventService(IEventDal EventDal
        //ILoggingService loggingService,
        //IEventDal EventDal,
        //IAuditDal auditDal
       // IEventBalanceService balsvc
        ) 
        {
            _EventDal = EventDal;
            // _EventBalService = balsvc;
        }

        public async Task<EventModel?> GetById(int EventId)
        {           
            return _EventDal.GetById(EventId);
        }


        public async Task<List<EventModel>> GetAll()
        {            
            return _EventDal.GetAll();
        }

        public async Task<int> CreateEvent(EventModel Event)
        {
            //write validations here
            var newEventId = _EventDal.CreateEvent(Event);
            return newEventId;
        }

        public async Task UpdateEvent(EventModel Event)
        {
            //write validations here 
            _EventDal.UpdateEvent(Event);
        }

        public async Task DeleteEvent(int EventId)
        {            
            try
            {
                //if(balservice.getBal(EventId) = 0)
                _EventDal.DeleteEvent(EventId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Event Id:{EventId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
