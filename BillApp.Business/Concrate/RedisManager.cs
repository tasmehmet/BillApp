using BillApp.Business.Abstract;
using BillApp.DataAccess.Abstract;
using BillApp.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.Business.Concrate
{
    public class RedisManager : IRedisService
    {
        private readonly IRedisDal _redisDal;
        public RedisManager(IRedisDal redisDal)
        {
            _redisDal = redisDal;
        }
        public IEnumerable<BillsDto> Get()
        {
            return _redisDal.Get();
        }

        public bool KeyExists(string key)
        {
            return _redisDal.KeyExists(key);
        }

        public void Set(BillsDto model)
        {
            _redisDal.Set(model);
        }
    }
}
