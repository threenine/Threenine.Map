using System;
using Xunit;
using AutoMapper;
using PhilosophicalMonkey;
using Threenine.Map;

namespace Threenine.Map.Tests
{
    public class MappingTests
    {
        public MappingTests()
        {
            
            var seedTypes = new Type[] { typeof(TestDomainObject) };
            var assemblies = Reflect.OnTypes.GetAssemblies(seedTypes);
            var typesInAssemblies = Reflect.OnTypes.GetAllExportedTypes(assemblies);
            MapConfigurationFactory.LoadAllMappings(typesInAssemblies);
        }


        [Fact]
        public void Test1()
        {
            
            var obj  = new TestDomainObject(){ Name = "foo"};

            var obj2 = Mapper.Map<TestEntityObject>(obj);



            Assert.Equal(obj.Name, obj2.Name);


        }
    }
}
