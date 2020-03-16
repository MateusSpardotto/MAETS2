using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class GenericMapper
    {
        public static List<Target> ToViewModel<Source,Target>(this IEnumerable<Source> data)
        {
            List<Target> targetData = new List<Target>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Target>();
            });
            IMapper mapper = configuration.CreateMapper();

            foreach (Source item in data)
            {
                targetData.Add(mapper.Map<Source, Target>(item));
            }
            return targetData;
        }
    }
}
