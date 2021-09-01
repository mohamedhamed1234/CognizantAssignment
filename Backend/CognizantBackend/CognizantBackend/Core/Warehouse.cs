using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantBackend.Core
{
    public class Warehouse
    {
        public string _id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public Cars cars { get; set; }
    }
}
