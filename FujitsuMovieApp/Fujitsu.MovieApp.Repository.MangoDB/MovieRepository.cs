using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fujitsu.MovieApp.Common.DomainModel;
using Fujitsu.MovieApp.Common.Interfaces;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Fujitsu.MovieApp.Repository.MangoDB
{
    public class MovieRepository : IMovieRepository
    {
        private MongoClient client;
        private IMongoDatabase db;

        public MovieRepository(string connectionString)
        {
            BsonClassMap.RegisterClassMap<Movie>(cm =>
            {
                cm.AutoMap();
                cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapIdMember(c => c.id).SetIdGenerator(new StringObjectIdGenerator());
            });

            client = new MongoClient(connectionString);
            db = client.GetDatabase("movie");
        }

        public string Create(Movie movie)
        {
            var movies = db.GetCollection<Movie>("movie");
            movies.InsertOne(movie);

            if (string.IsNullOrEmpty(movie.id))
                throw new Exception("MongoDB create operation failed for title:" + movie.title);

            return movie.id;
        }

        public void Delete(string id)
        {
            var movies = db.GetCollection<Movie>("movie");
            var filter = Builders<Movie>.Filter.Eq(e => e.id, id);

            var result = movies.DeleteOne(filter);

            if (result.DeletedCount != 1)
                throw new Exception("MongoDB delete operation failed for Id: " + id);
        }

        public Movie Retrieve(string id)
        {
            Movie movie = null;
            var client = new MongoClient("mongodb+srv://service:rSSCDZTIZzwPRsnEHGvY@cluster0-iv5oy.mongodb.net/movie?retryWrites=true");
            var db = client.GetDatabase("movie");
            var movies = db.GetCollection<Movie>("movie");

            var query = from e in movies.AsQueryable()
                        where e.id == id
                        select e;

            var result = query.FirstOrDefault();

            return result;
        }

        public IEnumerable<Movie> RetrieveAll()
        {
            Movie movie = null;
            var client = new MongoClient("mongodb+srv://service:rSSCDZTIZzwPRsnEHGvY@cluster0-iv5oy.mongodb.net/movie?retryWrites=true");
            var db = client.GetDatabase("movie");
            var movies = db.GetCollection<Movie>("movie");
            var result = movies.AsQueryable().AsEnumerable();
            return result;
        }

        public void Update(Movie movie)
        {
            var movies = db.GetCollection<Movie>("movie");
            var filter = Builders<Movie>.Filter.Eq(e => e.id, movie.id);

            var result = movies.ReplaceOne(filter, movie);

            if (result.ModifiedCount != 1)
                throw new Exception("MongoDB update operation failed for Id: " + movie.id);
        }
    }




}
