using Microsoft.AspNetCore.Identity;
using ToDoList.Core.Entities.Abstract;

namespace ToDoList.Entities.Concrete
{
    public class AppRole:IdentityRole<int>,IEntity
    {
    }
}
