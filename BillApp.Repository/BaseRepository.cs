using BillApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.Repository
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, new() where TContext : ApplicationDbContext
    {

        protected readonly TContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(TContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual async Task<TEntity> GetByIdAsync(int? id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int? id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
