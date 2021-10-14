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

      //Arrange
      //Read the raw JSON data
      string json = File.ReadAllText("data.json");
      Assert.NotEmpty(json);

      //Act
      //Convert to C# object
      //Like JSON.parse()
      RootObject root = JsonConvert.DeserializeObject<RootObject>(json);

      //Assert
      Assert.Equal(147, root.features.Count);


      //this does not work for what I am looking for, but this was the demo:
      var inEastVillage = root.features
      .Where(feature => feature.properties.neighborhood == "East Village");

      var inEastVillagecount = inEastVillage.Count();

      Assert.Equal(2, inEastVillagecount);


    }
  }
  class RootObject
  {
    public string type { get; set; }
    public List<Feature> features { get; set; }
  }

  public class Feature
  {
    public string type { get; set; }
    public Properties properties { get; set; }
  }
  public class Properties
  {
    public string neighborhood { get; set; }
  }
}
