using ToDoList.Core.DataAccess.Abstract;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Abstract
{
    public interface IEventsDal: IEntityRepository<Event>
    {
    }
}
