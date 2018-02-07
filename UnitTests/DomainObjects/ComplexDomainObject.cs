using AutoMapper;
using EntityObjects;
using Threenine.Map;

namespace DomainObjects
{
    public class ComplexDomainObject  :ICustomMap
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }
        public void CustomMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ComplexDomainObject, SimpleEntity>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => string.Concat( src.Firstname, " ", src.LastName )))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => string.Concat( src.Title , " ", src.Summary)))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));
        
        //fba9d-83468-35e16-85b06-cf0ca
        }
    }

   
}