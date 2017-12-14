using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PhilosophicalMonkey;
using ReflectMap.Interface;


namespace ReflectMap
{
    public class MapConfigurationFactory
    {   
        public static MapperConfiguration CreateConfiguration(IList<Type> types)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
             {
                 LoadAllMappings(cfg, types);
             });


            return config;
        }


        public static void LoadAllMappings(IList<Type> types)
        {
            Mapper.Initialize(
                 cfg =>
                 {
                     LoadStandardMappings(cfg, types);
                     LoadCustomMappings(cfg, types);
                 });
        }


        public static void LoadAllMappings(IMapperConfigurationExpression config, IList<Type> types)
        {
            LoadStandardMappings(config, types);
            LoadCustomMappings(config, types);
        }


        public static void LoadCustomMappings(IMapperConfigurationExpression config, IList<Type> types)
        {
            var instancesToMap = (from t in types
                                  from i in Reflect.OnTypes.GetInterfaces(t)
                                  where Reflect.OnTypes.IsAssignable(t, typeof(ICustomMap)) &&
                                        !Reflect.OnTypes.IsAbstract(t) &&
                                        !Reflect.OnTypes.IsInterface(t)
                                  select InitializeCustomMappingObject(t)).ToArray();


            foreach (var map in instancesToMap)
            {
                map.CustomMap(config);
            }
        }

        private static ICustomMap InitializeCustomMappingObject(Type t)
        {
            return (ICustomMap)Activator.CreateInstance(t, true);
        }


        public static void LoadStandardMappings(IMapperConfigurationExpression config, IList<Type> types)
        {
            var mapsFrom = (from t in types
                            from i in Reflect.OnTypes.GetInterfaces(t)
                            where Reflect.OnTypes.IsGenericType(i) && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                                  !Reflect.OnTypes.IsAbstract(t) &&
                                  !Reflect.OnTypes.IsInterface(t)
                            select new
                            {
                                Source = Reflect.OnTypes.GetGenericArguments(i).First(),
                                Destination = t
                            }).ToArray();


            foreach (var map in mapsFrom)
            {
                config.CreateMap(map.Source, map.Destination);
            }


            var mapsTo = (from t in types
                          from i in Reflect.OnTypes.GetInterfaces(t)
                          where Reflect.OnTypes.IsGenericType(i) && i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                                !Reflect.OnTypes.IsAbstract(t) &&
                                !Reflect.OnTypes.IsInterface(t)
                          select new
                          {
                              Source = t,
                              Destination = Reflect.OnTypes.GetGenericArguments(i).First()
                          }).ToArray();


            foreach (var map in mapsTo)
            {
                config.CreateMap(map.Source, map.Destination);
            }


        }

    }
}
