﻿using DataModel;
using DataModel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookStoreAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Author> Get()
        {
            using(var ctx = new BookStoreContext())
            {
                return ctx.Authors.ToList();
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
