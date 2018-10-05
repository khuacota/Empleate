using Empleate.Data;
using Empleate.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Empleate.Repository
{
    public class EmpleateHandler<SUEntity> : IEmpleate<SUEntity> where SUEntity : class
    {
        protected readonly AppDbContext Context;

        public EmpleateHandler(AppDbContext context)
        {
            Context = context;
        }
        public void Add(SUEntity sUEntity)
        {
            Context.Set<SUEntity>().Add(sUEntity);
        }

        public void AddRange(IEnumerable<SUEntity> sUEntities)
        {
            Context.Set<SUEntity>().AddRange(sUEntities);
        }

        public IEnumerable<SUEntity> Find(Expression<Func<SUEntity, bool>> predicate)
        {
            return Context.Set<SUEntity>().Where(predicate);
        }

        public IEnumerable<SUEntity> GetAll()
        {
            return Context.Set<SUEntity>().ToList();
        }

        public SUEntity GetById(int id)
        {
            return Context.Set<SUEntity>().Find(id);
        }

        public void Remove(SUEntity sUEntity)
        {
            Context.Set<SUEntity>().Remove(sUEntity);
        }

        public void RemoveRange(IEnumerable<SUEntity> sUEntities)
        {
            Context.Set<SUEntity>().RemoveRange(sUEntities);
        }
    }
}
