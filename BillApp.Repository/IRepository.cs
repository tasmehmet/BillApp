using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetByIdAsync(int? id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int? id);
        int SaveChanges();
    }
}
