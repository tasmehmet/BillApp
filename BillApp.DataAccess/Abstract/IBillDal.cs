using BillApp.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.DataAccess.Abstract
{
    public interface IBillDal
    {
        IEnumerable<BillsDto> GetAll();
        Task<BillsDto> GetById(int? id);
        bool Insert(BillsDto model);
        bool Update(BillsDto model);
        bool Delete(int? id);
    }
}
