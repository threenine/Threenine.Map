using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MapperTests
{
    [CollectionDefinition("Mapping")]
    public class TestCollection :ICollectionFixture<MapperFixture>
    {
    }
}
