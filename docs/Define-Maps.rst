Mapping Interfaces
==================

There are three interfaces that enable the definition of mappings making;

1. IMapTo
2. IMapFrom
3. ICustomMap

IMapTo & IMapFrom
------------------

The IMapTo and IMapFrom interfaces enable the definition of simple mappings i.e.  If you have a database entity and domain entity 
that may have the same properies  eg.

A database entity that has two properties

::

    public class DatabaseEntity
    {
        public string Name {get;set;}
        public string Description {get;set;}
    }

A domain object with the same 2 properties with the same names



::

    public class DomainObject
    {
        public string Name {get;set;}
        public string Description {get;set;}
    }

You don't necessarily want to write mapping logic to map between the two objects. You have simply make use of the IMapTo and IMapFrom
interfaces to define the mappings

::

    public class DatabaseEntity : IMapTo<DomainObject>
    {
        public string Name {get;set;}
        public string Description {get;set;}
    }

Once the interface has been implemented and the designated class name supplied there is nothing else you need to do to implement the mapping.
The automapper libraries take care of all the mapping for you.

ICustomMap
----------

The ICustomMap interface is required if your objects require more complex mapping logic.  The interface requires
the implementation of a mapping method

::

     public interface ICustomMap
    {
        void CustomMap(IMapperConfigurationExpression configuration);
    }

It is in the CustomMap method that you can use all the power and functionality of Automapper to implement your required mapping logic

::
    
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
               
        }
    }