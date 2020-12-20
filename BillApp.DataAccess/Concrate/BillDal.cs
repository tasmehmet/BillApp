using AutoMapper;
using BillApp.DataAccess.Abstract;
using BillApp.Dto;
using BillApp.Entity;
using BillApp.Repository;
using BillApp.Repository.Abstact;
using BillApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.DataAccess.Concrate
{
    public class BillDal : IBillDal
    {
        private readonly BillsUow _billsUow;
        private readonly IMapper _mapper;
        public BillDal(IMapper mapper)
        {
            _billsUow = new BillsUow();
            _mapper = mapper;
        }
        public bool Delete(int? id)
        {
            bool isOk = false;
            _billsUow.BillsRepository.Remove(id);
            _billsUow.BillsRepository.SaveChanges();
            isOk = true;
            return isOk;
        }

        public IEnumerable<BillsDto> GetAll()
        {
            var data = _billsUow.BillsRepository.GetAll();
            return _mapper.Map<IEnumerable<BillsDto>>(data);
        }

        public async Task<BillsDto> GetById(int? id)
        {
            var data = await _billsUow.BillsRepository.GetByIdAsync(id);
            return _mapper.Map<BillsDto>(data);
        }

        public bool Insert(BillsDto model)
        {
            bool isOk = false;
            _billsUow.BillsRepository.Add(_mapper.Map<Bills>(model));
            _billsUow.BillsRepository.SaveChanges();
            isOk = true;
            return isOk;
        }

        public bool Update(BillsDto model)
        {
            bool isOk = false;
            _billsUow.BillsRepository.Update(_mapper.Map<Bills>(model));
            _billsUow.BillsRepository.SaveChanges();
            isOk = true;
            return isOk;
        }
    }
}
