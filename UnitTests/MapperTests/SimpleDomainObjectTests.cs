using AutoMapper;
using DomainObjects;
using EntityObjects;
using FizzWare.NBuilder;
using System;
using Xunit;

namespace MapperTests
{
    [Collection("Mapping")]
    public class SimpleDomainObjectTests :IDisposable
    {
        private readonly MapperFixture _mapperFixture;
        public SimpleDomainObjectTests(MapperFixture fixture)
        {
            _mapperFixture = fixture;
        
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

        

        public void Dispose()
        {
            _mapperFixture?.Dispose();
        }
    }
}
