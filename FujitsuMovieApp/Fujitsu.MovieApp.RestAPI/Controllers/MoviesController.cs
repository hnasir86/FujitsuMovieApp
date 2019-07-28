using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fujitsu.MovieApp.Common.Interfaces;
using Fujitsu.MovieApp.Common.DomainModel;

namespace Fujitsu.MovieApp.RestAPI.Controllers
{
    public class MoviesController : ApiController
    {
        //Movie[] movies = new Movie[] { new Movie() { Id = 1, Title = "Lion King" }, new Movie() { Id = 2, Title = "The Matrix" } };

        // GET: api/Movies
        public IEnumerable<Movie> Get()
        {
            //return movies;
            return null;
        }

        // GET: api/Movies/5
        public IHttpActionResult Get(int id)
        {
            //if (id == 1)
            //    return Ok(movies[0]);
            //else if (id == 2)
            //    return Ok(movies[1]);

            //else
            //{
            //    return NotFound();
            //}
               return NotFound();

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
