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

    }

    static void DataJson()
      {
      string json = File.ReadAllText("data.json");
      RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
    }
    }
}
