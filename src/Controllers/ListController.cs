using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApi.Models;
using System.Collections;

namespace RestApi.Controllers
{
    public class ListController : ApiController
    {
        // GET: api/List
        public ArrayList Get()
        {
            ListPersistence listP = new ListPersistence();
            return listP.getLists();
        }

        // GET: api/List/5
        public ListTo Get(int id)
        {
            ListPersistence listP = new ListPersistence();
            ListTo listTo = listP.getList(id);

            return listTo;
        }

        // POST: api/List
        public HttpResponseMessage Post([FromBody]ListTo value)
        {
            ListPersistence listP = new ListPersistence();
            long id;
            id = listP.saveList(value);
            value.id = id;
            HttpResponseMessage resp = Request.CreateResponse(HttpStatusCode.Created);
            resp.Headers.Location = new Uri(Request.RequestUri, string.Format("list/{0}", id));
            return resp;

        }

        // PUT: api/List/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/List/5
        public void Delete(int id)
        {
        }
    }
}
