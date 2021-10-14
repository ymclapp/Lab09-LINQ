using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace LINQ_Lab09.Tests
{
  public class LINQTests
  {

    [Fact]
    public void Can_Read_File()
    {
      string json = File.ReadAllText("data.json");

      Assert.NotEmpty(json);
    }
  }
}
