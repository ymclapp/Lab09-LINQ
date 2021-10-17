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
      //To show all neighborhoods
      {
        var AllNeighborhoods = from neighborhood in root.features select neighborhood;
        var AllNeighborhoodscount = AllNeighborhoods.Count();

        foreach(var Neighborhoods in AllNeighborhoods)//shows a line item for each of the 147, but it says Here are the neighborhoods System.Linq.Enumerable+SelectListIterator`2[LINQ_Lab09.Feature,LINQ_Lab09.Feature]
        Console.WriteLine($"Here are the neighborhoods {Neighborhoods.properties.neighborhood}");
        Console.WriteLine($"Total: {AllNeighborhoodscount} ");
      }
      //Console.WriteLine($"Total: {AllNeighborhoodscount} ");
      //Console.WriteLine("This should be where the neighborhoods count is {");
    }
    }
}
