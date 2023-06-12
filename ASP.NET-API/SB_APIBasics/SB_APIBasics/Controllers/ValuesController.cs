﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SB_APIBasics.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> values = new List<string>
        { 
            "Subhasish", "Asmita", "Adrita"
        };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return values;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return values[id];
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            values.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            values[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            values.RemoveAt(id);
        }
    }
}
