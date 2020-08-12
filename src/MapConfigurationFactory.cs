/* Copyright (c) threenine.co.uk . All rights reserved.
 
   GNU GENERAL PUBLIC LICENSE  Version 3, 29 June 2007
   This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Threenine.Map
{
    public class MapConfigurationFactory
    {
       public static void Scan<TType>(Func<AssemblyName, bool> assemblyFilter = null)
        {
            var target = typeof(TType).Assembly;

            bool LoadAllFilter(AssemblyName x) => true;

            var assembliesToLoad = target.GetReferencedAssemblies()
                .Where(assemblyFilter ?? LoadAllFilter)
                .Select(Assembly.Load)
                .ToList();

            assembliesToLoad.Add(target);

            LoadMapsFromAssemblies(assembliesToLoad.ToArray());
        }

       private static void LoadMapsFromAssemblies(params Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(a => a.GetExportedTypes()).ToArray();
            LoadAllMappings(types);
        }


        private static void LoadAllMappings(IList<Type> types)
        {
            Mapper.Initialize(
                cfg =>
                {
                    LoadStandardMappings(cfg, types);
                    LoadCustomMappings(cfg, types);
                });
        }
        
        private static void LoadCustomMappings(IMapperConfigurationExpression config, IList<Type> types)
        {
            var instancesToMap = (from t in types
                from i in t.GetInterfaces()
                where typeof(ICustomMap).IsAssignableFrom(t) &&
                      !t.IsAbstract &&
                      !t.IsInterface
                select (ICustomMap) Activator.CreateInstance(t)).ToArray();


            foreach (var map in instancesToMap)
            {
                map.CustomMap(config);
            }
        }
        
        private static void LoadStandardMappings(IMapperConfigurationExpression config, IList<Type> types)
        {
            var mapsFrom = (from t in types
                from i in t.GetInterfaces()
                where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                      !t.IsAbstract &&
                      !t.IsInterface
                select new
                {
                    Source = i.GetGenericArguments()[0],
                    Destination = t
                }).ToArray();


            foreach (var map in mapsFrom)
            {
                config.CreateMap(map.Source, map.Destination);
            }


            var mapsTo = (from t in types
                from i in t.GetInterfaces()
                where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                      !t.IsAbstract &&
                      !t.IsInterface
                select new
                {
                    Source = i.GetGenericArguments()[0],
                    Destination = t
                }).ToArray();


            foreach (var map in mapsTo)
            {
                config.CreateMap(map.Source, map.Destination);
            }
        }
    }
}