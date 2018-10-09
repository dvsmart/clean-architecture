using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Q.Web.Controllers.Settings.CustomEntityManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormControlController : ControllerBase
    {
        // GET: api/FormControl
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FormControl/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FormControl
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FormControl/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
