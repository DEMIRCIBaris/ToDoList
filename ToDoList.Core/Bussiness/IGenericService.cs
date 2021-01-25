using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDoList.Core.Entities.Abstract;

namespace ToDoList.Core.Bussiness
{
    public interface IGenericService<Table> where Table : class, IEntity, new()
    {
        //Create Read Update Delete
        Table Get(Expression<Func<Table, bool>> filter);
        List<Table> GetList(Expression<Func<Table, bool>> filter = null);
        void Add(Table entity);
        void Update(Table entity);
        void Delete(Table entity);
    }
}
