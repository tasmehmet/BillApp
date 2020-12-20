using Autofac;
using AutoMapper;
using BillApp.DataAccess.Abstract;
using BillApp.DataAccess.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.IoC
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BillDal>().As<IBillDal>();
            builder.RegisterType<Mapper>().As<IMapper>();
            builder.RegisterType<RedisDal>().As<IRedisDal>();
        }
    }
}
