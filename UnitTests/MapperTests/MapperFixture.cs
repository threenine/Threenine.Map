using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Threenine.Map;
using Xunit;

namespace MapperTests
{
    public class MapperFixture : IDisposable
    {
        public MapperFixture()
        {
            MapConfigurationFactory.Scan<MapperFixture>();
        }

        public void Dispose()
        {
          
            // Do "global" teardown here; Only called once.
        }
    }

}
