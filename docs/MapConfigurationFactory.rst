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

