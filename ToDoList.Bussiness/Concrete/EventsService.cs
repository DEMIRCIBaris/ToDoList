using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDoList.Bussiness.Abstract;
using ToDoList.DataAccess.Abstract;
using ToDoList.Entities.Concrete;

namespace ToDoList.Bussiness.Concrete
{
    public class EventsService : IEventsService
    {
        private readonly IEventsDal eventsDal;

        public EventsService(IEventsDal eventsDal)
        {
            this.eventsDal = eventsDal;
        }
        public void Add(Event entity)
        {
            eventsDal.Add(entity);
        }

        public void Delete(Event entity)
        {
            eventsDal.Delete(entity);
        }

        public Event Get(Expression<Func<Event, bool>> filter)
        {
            return eventsDal.Get(filter);
        }

        public List<Event> GetList(Expression<Func<Event, bool>> filter = null)
        {
            return eventsDal.GetList(filter);
        }

        public void Update(Event entity)
        {
            eventsDal.Update(entity);
        }
    }
}
