using CognizantBackend.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantBackend.Data
{
    public class DataLoader
    {

        string filePath;
        public DataLoader(String filePath)
        {
            this.filePath = filePath;
        }
        
        public Warehouses LoadData()
        {
            Warehouses warehouse = JsonConvert.DeserializeObject<Warehouses>(File.ReadAllText(filePath));

            return warehouse ;
        }
    }
}
