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
      //var Allneighborhoods = Feature
      //.Where(feature => feature.properties.neighborhood != "");
      {
        var AllNeighborhoods = from neighborhood in root.features
                               select neighborhood;
        var AllNeighborhoodscount = AllNeighborhoods.Count();
      }
      Console.WriteLine($"Total:  ");
      Console.WriteLine("This should be where the neighborhoods count is");
    }
    }
}
