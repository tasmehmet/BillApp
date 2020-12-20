using Autofac;
using BillApp.Business.Concrate;
using BillApp.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.IoC
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BillManager>().As<IBillService>();
            builder.RegisterType<RedisManager>().As<IRedisService>();
        }
    }
}
