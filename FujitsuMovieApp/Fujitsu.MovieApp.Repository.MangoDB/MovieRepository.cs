using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fujitsu.MovieApp.Common;
using Fujitsu.MovieApp.Common.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Fujitsu.MovieApp.Repository.MangoDB
{
    public class MovieRepository : IMovieRepository
    {
        private MongoClient client;
        private IMongoDatabase db;

        public MovieRepository()
        {
             client = new MongoClient("mongodb+srv://service:rSSCDZTIZzwPRsnEHGvY@cluster0-iv5oy.mongodb.net/movie?retryWrites=true");
             db = client.GetDatabase("movie");
        }

        public int Create(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Movie Retrieve(int id)
        {
            Movie movie = null;
            var client = new MongoClient("mongodb+srv://service:rSSCDZTIZzwPRsnEHGvY@cluster0-iv5oy.mongodb.net/movie?retryWrites=true");
            var db = client.GetDatabase("movie");

            var collList = db.ListCollections().ToList();
            var movies = db.GetCollection<BsonDocument>("movie");
            var resultDoc = movies.Find(new BsonDocument()).ToList();

            return movie;
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
