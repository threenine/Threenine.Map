using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DomainObjects;
using EntityObjects;
using FizzWare.NBuilder;
using Threenine.Map;
using Xunit;

namespace MapperTests
{
    public class ComplexDomainObjectTests : IClassFixture<MapperFixture>, IDisposable
    {
        private readonly MapperFixture fixture;
        public ComplexDomainObjectTests(MapperFixture fix)
        {
            fixture = fix;
         
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
            fixture?.Dispose();
        }
    }
}
