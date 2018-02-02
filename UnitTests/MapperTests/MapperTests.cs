using DomainObjects;
using EntityObjects;
using Xunit;
using Threenine.Map;
using FizzWare.NBuilder;
using AutoMapper;

namespace MapperTests
{
    public class MapperTests
    {
        public MapperTests()
        {
          
            MapConfigurationFactory.Scan<MapperTests>();

        }


        [Fact]
        public void ShouldMapSimpleObject()
        {
            var testobj = Builder<SimpleDomainObject>.CreateNew().Build();

           var ent = Mapper.Map<SimpleEntity>(testobj);

            Assert.NotNull(ent);
            Assert.Equal(ent.Name, testobj.Name);


        }
    }
}
