using System;
using AutoMapper;

namespace SMC.Application.Mapper
{
    public class TaskMapper
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            MapperConfiguration config = new(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<TaskMappingProfile>();
            }); 
            
            return config.CreateMapper();
        });

        public static IMapper Mapper => Lazy.Value;
    }
}