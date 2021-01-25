using System;
using ToDoList.Core.Entities.Abstract;

namespace ToDoList.Entities.Concrete
{
    public class Event:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Color { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
