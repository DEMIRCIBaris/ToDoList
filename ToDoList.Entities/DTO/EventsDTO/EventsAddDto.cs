using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Entities.DTO.EventsDTO
{
    public class EventsAddDto
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Color { get; set; }
    }
}
