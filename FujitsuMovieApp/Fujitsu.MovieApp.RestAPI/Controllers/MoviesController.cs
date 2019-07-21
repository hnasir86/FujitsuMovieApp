using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fujitsu.MovieApp.Common.Interfaces;
using Fujitsu.MovieApp.Common;

namespace Fujitsu.MovieApp.RestAPI.Controllers
{
    public class MoviesController : ApiController
    {
        // GET: api/Movies
        public IEnumerable<Movie> Get()
        {
            return new Movie[] { new Movie() { Id = 1,  Title = "Lion King" } , new Movie() { Id = 1, Title = "The Matrix" } };
        }

        // GET: api/Movies/5
        public Movie Get(int id)
        {
            return new Movie() { Id = 1, Title = "The Matrix" };
        }

        // POST: api/Movies
        public void Post([FromBody]Movie value)
        {

        }

        // PUT: api/Movies/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Movies/5
        public void Delete(int id)
        {
        }
    }
}
