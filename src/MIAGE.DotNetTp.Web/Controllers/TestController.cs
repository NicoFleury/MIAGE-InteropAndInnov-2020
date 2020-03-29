using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MIAGE.DotNetTp.Web.Models;
using MIAGE.DotNetTp.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MIAGE.DotNetTp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public IDataService<Test> TestService { get; set; }

        public TestController(IDataService<Test> testService)
        {
            TestService = testService;
        }

        // GET: api/Test
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(TestService.GetAll());
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Test
        [HttpPost]
        public IActionResult Post([FromBody] Test value)
        {
            var test = TestService.Add(value);
            return CreatedAtAction("Get", new { id = test.Id.ToString() }, test);

        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
