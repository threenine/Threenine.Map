using System;
using AutoMapper;

namespace ReflectMap.Interface
{
    public interface ICustomMap
    {
        void CustomMap(IMapperConfigurationExpression configuration);
    } 
}
