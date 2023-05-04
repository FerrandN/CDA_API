using cereales.Db;
using cereales.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cereales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CerealsController : ControllerBase
    {
        CerealDbContext context;

        public CerealsController() : base()
        {
            context = new CerealDbContext();
        }

        // GET: api/<CerealsController>
        [HttpGet]
        public IEnumerable<Cereal> Get()
        {
            return context.Cereals.ToList();
        }

        // GET api/<CerealsController>/5
        [HttpGet("{id}")]
        public Cereal? Get(int id)
        {
            return context.Cereals.FirstOrDefault(c => c.CerealId == id);
        }

        // POST api/<CerealsController>
        [HttpPost]
        public void Post([FromBody] Cereal value)
        {
            if (value != null)
            {
                //if (StringIsValid(value.Name) && IntIsValid(value.Protein) && IntIsValid(value.Calories))
                //{
                    context.Cereals.Add(value);
                    context.SaveChanges();
                //}
            }
        }

        // PUT api/<CerealsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cereal value)
        {
            if (value != null)
            {
                //if(StringIsValid(value.Name) && IntIsValid(value.Protein) && IntIsValid(value.Calories))
                //{
                    value.CerealId = id;
                    context.Cereals.Update(value);
                    context.SaveChanges();
                //}
            }

            /*if(this.Get(id) is Cereal cereal && value.CerealId == cereal.CerealId)
            {
                
            }*/
        }

        // DELETE api/<CerealsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (this.Get(id) is Cereal cer)
            {
                context.Cereals.Remove(cer);
                context.SaveChanges();
            }
        }
        /*
        public bool StringIsValid(string s)
        {
            Regex rx = new Regex(@"^[A-zÀ-ú]*$");
            Match m = rx.Match(s);
            if(m.Success)
            {
                return true;
            }
            return false;
        }

        public bool IntIsValid(int i)
        {
            Regex rx = new Regex(@"^[[:digit:]]*$");
            Match m = rx.Match(i.ToString());
            if (m.Success)
            {
                return true;
            }
            return false;
        }
        */
    }
}
