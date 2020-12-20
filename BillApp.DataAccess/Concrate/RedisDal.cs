using BillApp.Caching;
using BillApp.DataAccess.Abstract;
using BillApp.Dto;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillApp.DataAccess.Concrate
{

    public class RedisDal : IRedisDal
    {
        private readonly IRedisService _redisService;
        private readonly IDatabase _redisDb;
        private string redisKey = "Bills";
        public RedisDal(IRedisService redisService)
        {
            _redisService = redisService;
            _redisDb = _redisService.GetDatabase(1);
        }
        public IEnumerable<BillsDto> Get()
        {
            var redisData = _redisDb.SetMembers(redisKey);
            var billsDto = redisData.Select(x => JsonConvert.DeserializeObject<BillsDto>(x));
            return billsDto;
        }
        public bool KeyExists(string key)
        {
            return _redisDb.KeyExists(key);
        }
        public void Set(BillsDto model)
        {
            string jsonBill = JsonConvert.SerializeObject(model);
            _redisDb.SetAdd(redisKey, jsonBill);
        }
    }
}
