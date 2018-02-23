Mapping Configuration Factory
=============================

The MapConfigurationFactory is the mechanism you'll use to register your Mappings within your application. There are a 
number of methods available to help you to do so. However the most popular and easiest one to use is the Scan method.

Scan
----

The Scan method makes use of Reflection to query all referenced assemblies to all the Types that implement the IMapTo, IMapFrom and
the ICustomMap interfaces and register them within your application domain.

To do so ise really easy, for instance if you are working on a Web Application (MVC or API), all you need to do is within you
Configure method is 

::


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        { 
            //Set up code for automapper configuration 
            MapConfigurationFactory.Scan<Startup>();     
        }
    }

Your mappings will now be available throughout your application.  So now making any mapping call such  as;

::

        public IEnumerable<Referrer> GetAllActive()
        {
            var threats = _unitOfWork.GetRepository<Threat>()
                .Get(predicate: x => x.Status.Name == Enabled && x.ThreatType.Name == Referer ).AsEnumerable();
          return Mapper.Map<IEnumerable<Referrer>>(source: threats);
          
        }

Will result in your Mapping being invoked

LoadMapsFromAssemblies
----------------------

If speed and optimisation is a concern and you would rather explicitly pass in your assemblies containing your mapping logic you can do so, making use of the `LoadMapsFromAssemblies`
method. It accepts a `params` array of assemblies, which you can supply an unlimited assemblies to it containing your mapping logic.

One way to do so would be to define a helper method to return an assembly by passing name to it, then retrieve the assmebly from those names
::
    
    public class GetMappings
    {
        public void Get()
        {
            var domainObjects = GetAssemblyByName("DomainObjects");
            var entityObjects = GetAssemblyByName("EntityObjects");

            MapConfigurationFactory.LoadMapsFromAssemblies(domainObjects,  entityObjects);
        }

        private Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == name);
        }
    }

 
LoadAllMappings
---------------
If you only want to load mappings from a particular assembly then you can make use of `LoadAllMappings` making use of a smilar stategy.

::
    
    public class GetMappings
    {
        public void Get()
        {
            var domainObjects = GetAssemblyByName("DomainObjects");
            MapConfigurationFactory.LoadAllMappings(domainObjects.GetTypes());
        }

        private Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == name);
        }
    }

