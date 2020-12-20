using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.Caching
{
    public class RedisService : IRedisService
    {
        private  ConnectionMultiplexer _redis;

        public void Connect()
        {
            _redis = ConnectionMultiplexer.Connect("redis-19955.c114.us-east-1-4.ec2.cloud.redislabs.com:19955,password=ElLK2aVBW03SbZE1wW5oSWDcOpg7sxyn");
        }

        public IDatabase GetDatabase(int id)
        {
            return _redis.GetDatabase(id);
        }
    }
}
