using BillApp.Data;
using BillApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.Repository.Abstact
{
    public class BillRepository<TEntity> : BaseRepository<TEntity, ApplicationDbContext> where TEntity : class, new()
    {
        public BillRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
