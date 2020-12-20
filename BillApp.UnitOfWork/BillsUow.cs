using BillApp.Data;
using BillApp.Entity;
using BillApp.Repository;
using BillApp.Repository.Abstact;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.UnitOfWork
{
    public class BillsUow : IUnitOfWork
    {
        public ApplicationDbContext _context;
        private bool _disposed = false;

        public BillsUow()
        {
            _context = new ApplicationDbContext();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        private IRepository<TEntity> GetRepositoryInstance<TEntity>(BillRepository<TEntity> repo) where TEntity : class, new()
        {
            if (repo == null)
                repo = new BillRepository<TEntity>(this._context);

            return repo;
        }
        private BillRepository<Bills> billRepository;
        public IRepository<Bills> BillsRepository
        {
            get { return GetRepositoryInstance<Bills>(billRepository); }
        }
    }
}
