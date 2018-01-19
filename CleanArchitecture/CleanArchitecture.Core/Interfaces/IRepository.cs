using CleanArchitecture.Core.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(string id);
        IReadOnlyList<T> List(Expression<Func<T, bool>> filter = null);
        Task<ICollection<T>> ListAsync(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
