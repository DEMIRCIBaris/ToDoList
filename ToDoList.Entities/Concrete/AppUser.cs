using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using ToDoList.Core.Entities.Abstract;

namespace ToDoList.Entities.Concrete
{
    public class AppUser:IdentityUser<int>,IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Event> Events { get; set; }
    }
}
