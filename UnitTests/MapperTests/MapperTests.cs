using System;
using Xunit;
using PhilosophicalMonkey;
using Threenine.Map;
using FizzWare.NBuilder;

namespace MapperTests
{
    public class MapperTests
    {
        public MapperTests()
        {
            var seedTypes = new Type[]{ typeof(DomainObjects.Marker )};
            var assemblies = Reflect.OnTypes.GetAssemblies(seedTypes);
            var typesInAssemblies = Reflect.OnTypes.GetAllExportedTypes(assemblies);
            MapConfigurationFactory.LoadAllMappings(typesInAssemblies);

        }


        [Fact]
        public void ShouldMapSimpleObject()
        {
            var testobj = Builder<SimpleDomainObject>.CreateNew().Build();

            Assert.NotNull(testobj);


        }
    }
}
