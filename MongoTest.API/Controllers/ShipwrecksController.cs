using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MongoTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
