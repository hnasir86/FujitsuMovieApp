using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fujitsu.MovieApp.Repository.MangoDB;
using Fujitsu.MovieApp.Common.DomainModel;
using System.Linq;
using Fujitsu.MovieApp.Common.Interfaces;

namespace Fujitsu.MovieApp.Test
{
    [TestClass]
    public class MovieRepository_Update
    {
        IMovieRepository repository;
        Movie testMovie;

        [TestInitialize]
        public void init()
        {
            repository = new MovieRepository(Utils.GetConnectionStringForMongoDB());
            testMovie = new Movie() { title = "Update Test" };
            repository.Create(testMovie);
        }

        [TestCleanup]
        public void cleanup()
        {
            repository.Delete(testMovie.id);
        }

        [TestMethod]
        public void ShouldUpdateTheMovieWithNewValues()
        {
            string newTitle = "title updated";
            testMovie.title = newTitle;

            repository.Update(testMovie);

            Movie verifyMovie = repository.Retrieve(testMovie.id);

            Assert.IsNotNull(verifyMovie);
            Assert.AreEqual(verifyMovie.title, newTitle);
        }
    }
}
