using BillApp.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.DataAccess.Abstract
{
    public interface IRedisDal
    {
        void Set(BillsDto model);
        IEnumerable<BillsDto> Get();
        bool KeyExists(string key);
    }
}
