using ToDoList.Core.DataAccess.EntityFramework;
using ToDoList.DataAccess.Abstract;
using ToDoList.DataAccess.Concrete.EntityFramework.Context;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Concrete.EntityFramework
{
    public class EfEventDal: EfEntityRepositoryBase<MyDataContext, Event>,IEventsDal
    {
    }
}
