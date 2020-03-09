using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleRESTService.Controllers
{
    [Route("api/[controller]")]
    public class LibraryController : Controller
    {
        private static List<Bog> Library = new List<Bog>()
        {
            new Bog("UML","Larman",654,"9780133594140"),
            new Bog("The Grass is Always Greener","Jeffrey Archer",200 ,"1-86092-049-7"),
            new Bog("Murder!","Arnold Bennett (1867-1931)",700,"1-86092-012-8")
        };

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return Library;
        }

        // GET api/<controller>/5
        [HttpGet("{ISBN13}")]
        public Bog Get(string ISBN13)
        {
            return Library.Find(x => x.ISBN13 == ISBN13);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            Library.Add(JsonConvert.DeserializeObject<Bog>(value));
        }

        // PUT api/<controller>/5
        [HttpPut("{ISBN13}")]
        public void Put(string ISBN13, [FromBody]string value)
        {

            List<Bog> bookExist = Library.FindAll(x => x.ISBN13 == ISBN13);

            if (bookExist.Count > 0)
            {
                Bog bookToAdd = JsonConvert.DeserializeObject<Bog>(value);
                Library.Add(bookToAdd);
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{ISBN13}")]
        public void Delete(string ISBN13)
        {
            List<Bog> bookExist = Library.FindAll(x => x.ISBN13 == ISBN13);

            if (bookExist.Count > 0)
            {
                Library.RemoveAll(x => x.ISBN13 == ISBN13);
            }
        }
    }
}
