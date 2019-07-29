using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fujitsu.MovieApp.Repository.MangoDB;
using Fujitsu.MovieApp.Common.Interfaces;
using Fujitsu.MovieApp.Common.DomainModel;

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
    }
}
