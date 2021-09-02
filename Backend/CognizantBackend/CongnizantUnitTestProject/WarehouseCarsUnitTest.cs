using CognizantBackend.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace CongnizantUnitTestProject
{
    public class WarehouseCarsUnitTest
    {

        private readonly IConfiguration _configuration;
        public WarehouseCarsUnitTest()
        {

          
        }
        public int getPath()
        {
            return 0;
        }

        [Fact]
        public void IndexGet_ReturnsWarehouseCars()
        {
            // Arrange

            var inMemorySettings = new Dictionary<string, string> {
                {"FilePath", "../../../warehouses.json"},
                };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var controller = new WarehouseDataController(configuration);

           
            // Act

            System.Collections.Generic.IEnumerable<CognizantBackend.Core.Warehouse> result = controller.WarehouseCars().ToList();

            // Assert
            Assert.Equal(4, result.Count());

        }
    }
}
