using F2019Places.Controllers;
using F2019Places.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace F2019PlacesTest
{
    [TestClass]
    public class DestinationsControllerTest
    {
        private f19Context db;
        DestinationsController destinationsController;
        List<Destination> destinations = new List<Destination>();

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<f19Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            db = new f19Context(options);

            var region = new Region
            {
                RegionId = 871,
                Name = "Oceania"
            };

            destinations.Add(new Destination
            {
                DestinationId = 534,
                Name = "One Cool Place",
                Location = "South Oz",
                Region = region
            });

            destinations.Add(new Destination
            {
                DestinationId = 535,
                Name = "Second Cool Place",
                Location = "West Oz",
                Region = region
            });

            destinations.Add(new Destination
            {
                DestinationId = 536,
                Name = "Third Cool Place",
                Location = "North Oz",
                Region = region
            });

            destinations.Add(new Destination
            {
                DestinationId = 536,
                Name = "Fourth Cool Place",
                Location = "East Oz",
                Region = region
            });

            foreach (var d in destinations)
            {
                db.Add(d);
            }

            db.SaveChanges();
            destinationsController = new DestinationsController(db);
        }
    }
}