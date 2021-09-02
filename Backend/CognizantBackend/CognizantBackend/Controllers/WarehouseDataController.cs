using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CognizantBackend.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using CognizantBackend.Data;
using Microsoft.Extensions.Configuration;

namespace CognizantBackend.Controllers
{
    [Route("api/[controller]")]
    public class WarehouseDataController : Controller
    {
        private readonly IConfiguration _configuration;
 
        public WarehouseDataController(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        [HttpGet("[action]")]
        public IEnumerable<Warehouse> WarehouseCars()
        {


        var filePathath = _configuration["FilePath"];

            DataLoader dataLoader = new DataLoader(filePathath);
            Warehouses warehouses = dataLoader.LoadData();


            var carsList = warehouses.warehouse
                .Select(x => new Warehouse()
                    {
                    _id = x._id,
                    name  = x.name,
                    location = x.location,
                    cars = new Cars()
                    {
                        vehicles = x.cars.vehicles.OrderBy(xx => xx.date_added).ToList(),
                        location = x.cars.location
                    }
                })
                .ToList();

            return carsList;




        }


        
    }
}