using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fujitsu.MovieApp.Repository.MangoDB;
using Fujitsu.MovieApp.Common.Interfaces;
using Fujitsu.MovieApp.Common.DomainModel;
using System.Net;
using System.IO;
using System.Net.Http;

namespace Fujitsu.MovieApp.Controllers
{
    public class MovieController : Controller
    {
        string connectionString = "mongodb+srv://service:rSSCDZTIZzwPRsnEHGvY@cluster0-iv5oy.mongodb.net/movie?retryWrites=true";
        IMovieRepository movieRepo;

        public MovieController()
        {
            //TODO Add dependency injection
            movieRepo = new MovieRepository(connectionString);
        }
        // GET: Movie
        public ActionResult Index()
        {
            var allMovies = movieRepo.RetrieveAll();
            return View(allMovies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(string id)
        {
            var movie = movieRepo.Retrieve(id);
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Movie movie = new Movie()
                {
                    actors = collection["actors"],
                    director = collection["director"],
                    image = collection["image"],
                    title = collection["title"],
                    year = int.Parse(collection["year"])
                };

                movieRepo.Create(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                //TODO Add logging
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(string id)
        {
            var movie = movieRepo.Retrieve(id);

            return View(movie);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                Movie movie = new Movie()
                {
                    id = id,
                    actors = collection["actors"],
                    director = collection["director"],
                    image = collection["image"],
                    title = collection["title"],
                    year = int.Parse(collection["year"])
                };

                movieRepo.Update(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                //TODO Add logging
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(string id)
        {
            var movie = movieRepo.Retrieve(id);
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                movieRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                //TODO Add logging
                return View();
            }
        }

        // GET: http://localhost:57304/movie/image?url=https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg%202009%20Edit%20|%20Details%20|%20Delete%20The%20life%20of%20David%20Gale%20Alan%20Parker%20Kevin%20Spacey%20https://m.media-amazon.com/images/M/MV5BMTAxMzU0NTgxNzZeQTJeQWpwZ15BbWU2MDQzNDkxNw@@._V1_UX182_CR0,0,182,268_AL_.jpg
        public FileResult Image(string url)
        {

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                var filetype = response.Content.Headers.ContentType.MediaType;
                var imageBytes = response.Content.ReadAsByteArrayAsync().Result;
                return File(imageBytes, filetype, url);
            }
        }
    }
}
