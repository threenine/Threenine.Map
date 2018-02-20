Mapping Interfaces
==================

There are three interfaces that enable the definition of mappings making;

1. IMapTo
2. IMapFrom
3. ICustomMap

The first two enable the definition of simple mappings i.e.  If you have a database entity and domain entity 
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


