using Threenine.Map;
using EntityObjects;

namespace DomainObjects
{
    public class SimpleDomainObject :  IMapTo<SimpleEntity>,  IMapFrom<SimpleEntity>
    {
         public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
   }
}