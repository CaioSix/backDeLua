using AutoMapper;
using DeLua.Data.Entities;
using DeLua.Data.ValueObjects;

namespace DeLua.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();

            });
            return mappingConfig;
        }
    }
}
