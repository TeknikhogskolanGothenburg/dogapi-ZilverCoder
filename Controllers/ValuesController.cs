using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using test2.Models;
using Newtonsoft.Json;

namespace dogapi_ZilverCoder.Controllers
{
    [Route("dogs/")]
    public class ValuesController : Controller
    {
        List<Dog> dogs = new List<Dog>();
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var files = System.IO.Directory.GetFiles("DogFiles","*.json");
            foreach(var file in files){
                dogs.Add(JsonConvert.DeserializeObject<Dog>
                (System.IO.File.ReadAllText(file)));
            }
            return dogs.Select(d => d.BreedName).ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            string success = "Something went wrong";
            var files = System.IO.Directory.GetFiles("DogFiles","*.json");
            foreach(var file in files){
                dogs.Add(JsonConvert.DeserializeObject<Dog>
                (System.IO.File.ReadAllText(file)));
            }
            for(int i=0; i < dogs.Count; i++)
            {
                if(dogs[i].BreedName == id)
                {
                    success = "Found him!";
                }
            }
            //return dogs[0].BreedName.ToString();
            return success;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var files = System.IO.Directory.GetFiles("DogFiles","*.json"); 
            foreach(var file in files){
                dogs.Add(JsonConvert.DeserializeObject<Dog>
                (System.IO.File.ReadAllText(file)));
            }
            test2.Models.Dog temp = new test2.Models.Dog();
            temp.BreedName = value;
            dogs.Add(temp);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            var files = System.IO.Directory.GetFiles("DogFiles","*.json"); 
            foreach(var file in files){
                dogs.Add(JsonConvert.DeserializeObject<Dog>
                (System.IO.File.ReadAllText(file)));
            }
            if(dogs[id] != null){
                dogs[id].BreedName = value;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
