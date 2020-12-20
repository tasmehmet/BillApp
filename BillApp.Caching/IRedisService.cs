using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.Caching
{
    public interface IRedisService
    {
        void Connect();
        IDatabase GetDatabase(int id);
    }
}
