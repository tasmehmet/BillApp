using AutoMapper;


namespace BillApp.Common.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
        }
    }
}
