using System;
using AutoMapper;

namespace Threenine.Map
{
    
    public interface ICustomMap
    {
        void CustomMap(IMapperConfigurationExpression configuration);
    } 
}