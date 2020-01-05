using AutoMapper;
using DomainObjects;
using EntityObjects;
using FizzWare.NBuilder;
using System;
using Xunit;

namespace MapperTests
{
    [Collection("Mapping")]
    public class ComplexDomainObjectTests : IDisposable
    {
        private readonly MapperFixture _mapperFixture;
        public ComplexDomainObjectTests(MapperFixture fixture)
        {
            _mapperFixture = fixture;
         
        }
        [Fact]
        public void ShouldMapComplexObject()
        {
            
            var testobj = Builder<ComplexDomainObject>.CreateNew().Build();
            var ent = Mapper.Map<SimpleEntity>(testobj);
            
          
            Assert.NotNull(ent);
            Assert.IsAssignableFrom<SimpleEntity>(ent);
            Assert.Equal(ent.Name, string.Concat(testobj.Firstname, " ", testobj.LastName));
            Assert.Equal(ent.Description, string.Concat(testobj.Title, " ", testobj.Summary));
        }

      
        public void Dispose()
        {
            _mapperFixture?.Dispose();
        }
    }
}
