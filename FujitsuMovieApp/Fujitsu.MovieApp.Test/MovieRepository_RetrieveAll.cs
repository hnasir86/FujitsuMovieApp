using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fujitsu.MovieApp.Repository.MangoDB;
using Fujitsu.MovieApp.Common.DomainModel;
using System.Linq;
using Fujitsu.MovieApp.Common.Interfaces;

namespace Fujitsu.MovieApp.Test
{
    [TestClass]
    public class MovieRepository_RetrieveAll
    {
        IMovieRepository repository;
        Movie testMovie1;
        Movie testMovie2;

        [TestInitialize]
        public void init()
        {
            repository = new MovieRepository(Utils.GetConnectionStringForMongoDB());
            testMovie1 = new Movie() { title = "RetrieveAll 1" };
            testMovie2 = new Movie() { title = "RetrieveAll 2" };
            repository.Create(testMovie1);
            repository.Create(testMovie2);
        }

        [TestCleanup]
        public void cleanup()
        {
            repository.Delete(testMovie1.id);
            repository.Delete(testMovie2.id);
        }

        [TestMethod]
        public void ShouldReturnAllMovies()
        {
            var movieList = repository.RetrieveAll();

            Assert.IsNotNull(movieList);
            Assert.AreEqual(movieList.Where(e => e.id == testMovie1.id || e.id == testMovie2.id).Count(), 2);
        }
    }
}
