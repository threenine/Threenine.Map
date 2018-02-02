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
            Assert.IsAssignableFrom<SimpleEntity>(ent);
            Assert.Equal(ent.Name, testobj.Name);
        }

        [Fact]
        public void ShouldMapComplexObject()
        {
            var testobj = Builder<ComplexDomainObject>.CreateNew().Build();
            var ent = Mapper.Map<SimpleEntity>(testobj);

            Assert.NotNull(ent);
            Assert.IsAssignableFrom<SimpleEntity>(ent);
            Assert.Equal(ent.Name, string.Concat(testobj.Firstname , " ", testobj.LastName));
            Assert.Equal(ent.Description, string.Concat(testobj.Title , " ", testobj.Summary));
        }
    }
}
