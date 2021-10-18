using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace LINQ_Lab09
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello New York!!");
      DataJson();
      //Neighborhoods();

    }

    static void DataJson()
      {
      string json = File.ReadAllText("data.json");
      RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
      Neighborhoods(root);
      }

    static void Neighborhoods(RootObject root)
    {
      
        var AllNeighborhoods = from neighborhood in root.features select neighborhood;
        var AllNeighborhoodscount = AllNeighborhoods.Count();

        foreach (var Neighborhoods in AllNeighborhoods)
        {
          Console.WriteLine($"Here are the neighborhoods {Neighborhoods.properties.neighborhood}");
          //Console.WriteLine($"Total: {AllNeighborhoodscount} ");

          //var NonBlankNeighborhoods = from AllNeighborhoods
          //select neighborhood
          //where neighborhood != "";


        }
        Console.WriteLine("-------------------------------------------------------------------------------------------------");
        Console.WriteLine($"Total neighborhood count is: {AllNeighborhoodscount} ");
        Console.WriteLine("-------------------------------------------------------------------------------------------------");


      var NonBlankNeighborhoods = root.features
        .Where(feature => (feature.properties.neighborhood != ""));
      //.Distinct();
      var NonBlankNeighborhoodsCount = NonBlankNeighborhoods.Count();

      foreach (var Neighborhoods in NonBlankNeighborhoods)
      {
        Console.WriteLine($"Here are the neighborhoods with the blank neighborhoods removed: {Neighborhoods.properties.neighborhood}");
      }

      Console.WriteLine("-------------------------------------------------------------------------------------------------");
      Console.WriteLine($"Total non-blank neighborhood count is:  {NonBlankNeighborhoodsCount}");
      Console.WriteLine("-------------------------------------------------------------------------------------------------");


      var AllDistinctneighborhoods = NonBlankNeighborhoods.GroupBy(NonBlankNeighborhoods => NonBlankNeighborhoods.properties.neighborhood).Select(IGrouping => IGrouping.First());
                                    
        //.Select(feature => feature.properties.neighborhood)
        //.Where(hoods => hoods != "")//get rid of .where to get ALL neighborhoods
        //.Distinct()
        //.OrderBy(hoods => hoods);

      var AllDistinctneighborhoodscount = AllDistinctneighborhoods.Count();

      foreach (var Neighborhoods in AllDistinctneighborhoods)
      {
        Console.WriteLine($"Here are the unique neighborhoods:  {Neighborhoods.properties.neighborhood}");
      }
      Console.WriteLine("-------------------------------------------------------------------------------------------------");
      Console.WriteLine($"Total unique neighborhood count is:  {AllDistinctneighborhoodscount}");
      Console.WriteLine("-------------------------------------------------------------------------------------------------");


    }//end of Neighborhoods
    }
}
