using BillApp.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.Business.Abstract
{
    public interface IRedisService
    {
        void Set(BillsDto model);
        IEnumerable<BillsDto> Get();
        bool KeyExists(string key);
    }
}
