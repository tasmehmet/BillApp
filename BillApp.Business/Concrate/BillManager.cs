using BillApp.Business.Abstract;
using BillApp.DataAccess.Abstract;
using BillApp.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.Business.Concrate
{
    public class BillManager : IBillService
    {
        private readonly IBillDal _billDal;
        public BillManager(IBillDal billDal)
        {
            _billDal = billDal;
        }
        public bool Delete(int? id)
        {
            return _billDal.Delete(id);
        }

        public IEnumerable<BillsDto> GetAll()
        {
            return _billDal.GetAll();
        }

        public Task<BillsDto> GetById(int? id)
        {
            return _billDal.GetById(id);
        }

        public bool Insert(BillsDto model)
        {
            return _billDal.Insert(model);
        }

        public bool Update(BillsDto model)
        {
            return _billDal.Update(model);
        }
    }
}
