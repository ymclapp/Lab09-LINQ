using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LINQ_Lab09
{
  public class RootObject
  {
    public string type { get; set; }
    public List<Feature> features { get; set; }
  }
}
