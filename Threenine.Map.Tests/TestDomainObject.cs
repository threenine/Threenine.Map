
using Threenine.Map;
namespace Threenine.Map.Tests
{


    public class TestDomainObject : IMapTo<TestEntityObject>
    { 
        public string Name { get; set; }
        public string Description { get; set; }

    }
}