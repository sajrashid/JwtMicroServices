using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;

namespace API1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IHttpContextAccessor _context;
        private readonly ILogger _logger;
   

        public ValuesController(IHttpContextAccessor context,ILogger<ValuesController> logger)
        {
            _logger = logger;
            _context = context;
           

        }


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //var name = (ClaimsIdentity)User.Identity.Name.ToString();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
