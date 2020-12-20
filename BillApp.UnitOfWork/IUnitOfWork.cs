using BillApp.Entity;
using BillApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Bills> BillsRepository { get; }
    }
}
