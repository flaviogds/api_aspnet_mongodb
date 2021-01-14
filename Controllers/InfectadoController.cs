using System;
using API.NET.Data.Collections;
using API.NET.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.NET.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedCollection;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public ActionResult AddElement([FromBody] IInfected m)
        {
            var infected = new Infected(m.Birth, m.Gender, m.Latitude, m.Longitude);

            _infectedCollection.InsertOne(infected);
            
            return StatusCode(201, "Adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult GetElemment(DateTime input)
        {
            var infected = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();

            return Ok(infected);   
        }

        [HttpDelete ("{_id}")]
        public ActionResult DeleteElement(string input)
        {
            _infectedCollection.DeleteOne(Builders<Infected>.Filter.Where(m => m._id == input));
            
            return Ok("Item excluido");
        }
    }
}