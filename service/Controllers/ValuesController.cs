using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using interfaces;
using System.Linq;

namespace service.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ServDbContext context;
        public ValuesController(ServDbContext context)
        {
            this.context = context;

            if (this.context.Items.Count() == 0)
            {
                this.context.Items.Add(new Item{ Id = Guid.NewGuid(), Code = "First", Name = "Первый элемент" });
                this.context.Items.Add(new Item{ Id = Guid.NewGuid(), Code = "Second", Name = "Второй элемент" });
                this.context.SaveChanges();
            }
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return this.context.Items.Select(i => $"{i.Id} - ({i.Code}, {i.Name});");
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
