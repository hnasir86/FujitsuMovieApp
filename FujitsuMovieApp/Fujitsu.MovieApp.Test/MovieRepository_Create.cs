using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fujitsu.MovieApp.Repository.MangoDB;
using Fujitsu.MovieApp.Common;

namespace Fujitsu.MovieApp.Test
{
    [TestClass]
    public class MovieRepository_Create
    {
        MovieRepository repository;
        Movie testMovie;
        int id = 0;


        [TestInitialize]
        public void init()
        {
            repository = new MovieRepository();
            testMovie = new Movie() { Title = "test movie" };

        }

        [TestCleanup]
        public void cleanup()
        {
            repository.Delete(id);
        }

        [TestMethod]
        public void ShouldCreateNewMovieRecordAndReturnItsId()
        {
            id = repository.Create(testMovie);
            
            Assert.IsTrue(id > 0);
        }
    }
}
