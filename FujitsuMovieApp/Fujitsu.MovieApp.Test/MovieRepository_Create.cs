using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fujitsu.MovieApp.Repository.MangoDB;
using Fujitsu.MovieApp.Common.DomainModel;
using Fujitsu.MovieApp.Common.Interfaces;

namespace Fujitsu.MovieApp.Test
{
    [TestClass]
    public class MovieRepository_Create
    {
        IMovieRepository repository;
        Movie testMovie;
        string id = string.Empty;


        [TestInitialize]
        public void init()
        {
            repository = new MovieRepository(Utils.GetConnectionStringForMongoDB());
            testMovie = new Movie() { title = "Create Movie Test" };
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
            var movie = repository.Retrieve(id);

            Assert.IsNotNull(movie);
            Assert.AreEqual(movie.id, id);
        }
    }
}
