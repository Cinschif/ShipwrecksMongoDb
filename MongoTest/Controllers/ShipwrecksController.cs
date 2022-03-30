using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace MongoTest.Controllers
{
    //http://localhost:5000/swagger/index.html
    //http://localhost:5000/api/Shipwrecks


    [Route("api/[controller]")]
    [ApiController]
    public class ShipwrecksController : ControllerBase
    {
        private readonly IMongoCollection<Shipwreck> _shipwreckCollection;

        public ShipwrecksController(IMongoClient client)
        {
            var database = client.GetDatabase("sample_geospatial");
            _shipwreckCollection = database.GetCollection<Shipwreck>("shipwrecks");
        }

        [HttpGet]
        public IEnumerable<Shipwreck> Get()
        {
            return _shipwreckCollection.Find(s => s.FeatureType == "Wrecks - Visible").ToList();
        }
    }
}
