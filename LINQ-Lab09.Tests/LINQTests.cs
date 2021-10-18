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

      Assert.Equal(147, root.features.Count);  //this is a property

      var Allneighborhoods = root.features
        .Where(feature => feature.properties.neighborhood !="");
       

      var Allneighborhoodscount = Allneighborhoods.Count();

      //Assert
      Assert.Equal(143, Allneighborhoodscount);  //this is all non-blank neighborhoods

    }

    [Fact]
    public void Gets_distinct_count()
    {

      //Arrange
      //Read the raw JSON data
      string json = File.ReadAllText("data.json");
      Assert.NotEmpty(json);

      //Act
      //Convert to C# object
      //Like JSON.parse()
      RootObject root = JsonConvert.DeserializeObject<RootObject>(json);

      Assert.Equal(147, root.features.Count);  //this is a property
    //Act
      var AllDistinctneighborhoods = root.features
        .Select(feature => feature.properties.neighborhood)
        .Where(hoods => hoods != "")//get rid of .where to get ALL neighborhoods
        .Distinct()
        .OrderBy(hoods => hoods);

      var AllDistinctneighborhoodscount = AllDistinctneighborhoods.Count();

      //Assert
      Assert.Equal(39, AllDistinctneighborhoodscount);  //this is all non-blank neighborhoods

    }

    [Fact]
    public void Get_ALL_neighborhoods_from_file()
    {

      //Arrange
      //Read the raw JSON data
      string json = File.ReadAllText("data.json");
      Assert.NotEmpty(json);

      //Act
      //Convert to C# object
      //Like JSON.parse()
      RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
      var Allneighborhoods = root.features;
      //.Where(feature =>
      //feature.properties.neighborhood != "");

      var Allneighborhoodscount = Allneighborhoods.Count();

      //Assert
      Assert.Equal(147, Allneighborhoodscount);  //this is ALL neighborhoods
    }

    [Fact]
    public void Get_non_blank_neighborhoods_from_file()
    {

      //Arrange
      //Read the raw JSON data
      string json = File.ReadAllText("data.json");
      Assert.NotEmpty(json);

      //Act
      //Convert to C# object
      //Like JSON.parse()
      RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
      var Allneighborhoods = root.features
      .Where(feature =>
      feature.properties.neighborhood != "");

      var Allneighborhoodscount = Allneighborhoods.Count();

      //Assert
      Assert.Equal(143, Allneighborhoodscount);  //this is ALL neighborhoods
    }

    [Fact]
    public void Get_East_Village_Neighborhood_count_from_file()
    {

      //Arrange
      //Read the raw JSON data
      string json = File.ReadAllText("data.json");
      Assert.NotEmpty(json);

      //Act
      //Convert to C# object
      //Like JSON.parse()
      RootObject root = JsonConvert.DeserializeObject<RootObject>(json);

      var inEastVillage = root.features
      .Where(feature =>
      feature.properties.neighborhood == "East Village");

      var inEastVillagecount = inEastVillage.Count();//this is a LINQ count that will count any IEnumberable that you tell it
      //Assert
      Assert.Equal(2, inEastVillagecount);
    }
  }
  
}
