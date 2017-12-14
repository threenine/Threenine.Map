namespace ReflectMapTests
{
    using ReflectMap.Interface;

    public class TestDomainObject : IMapTo<TestEntityObject>
    { 
        public string Name { get; set; }
        public string Description { get; set; }

    }
}