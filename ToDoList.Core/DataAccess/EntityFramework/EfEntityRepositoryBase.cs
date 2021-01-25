using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToDoList.Core.DataAccess.Abstract;
using ToDoList.Core.Entities.Abstract;

namespace ToDoList.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TContext, Table> : IEntityRepository<Table> where Table : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public void Add(Table entity)
        {
            using (var context = new TContext())
            {
                context.Set<Table>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Table entity)
        {
            using (var context = new TContext())
            {
                context.Set<Table>().Remove(entity);
                context.SaveChanges();
            }
        }

        public Table Get(Expression<Func<Table, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<Table>().FirstOrDefault(filter);
            }
        }

        public List<Table> GetList(Expression<Func<Table, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<Table>().ToList() : context.Set<Table>().Where(filter).ToList();
            }
        }

        public void Update(Table entity)
        {
            using (var context = new TContext())
            {
                context.Set<Table>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}
