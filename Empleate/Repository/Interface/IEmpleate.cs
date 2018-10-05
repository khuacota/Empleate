using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Empleate.Repository.Interface
{
    interface IEmpleate<SUEntity> where SUEntity : class
    {
        SUEntity GetById(int id);
        IEnumerable<SUEntity> GetAll();
        IEnumerable<SUEntity> Find(Expression<Func<SUEntity, bool>> predicate);

        void Add(SUEntity sUEntity);
        void AddRange(IEnumerable<SUEntity> sUEntities);

        void Remove(SUEntity sUEntity);
        void RemoveRange(IEnumerable<SUEntity> sUEntities);

    }
}
