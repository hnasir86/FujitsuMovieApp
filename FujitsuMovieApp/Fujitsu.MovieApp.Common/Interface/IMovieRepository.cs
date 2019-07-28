using Fujitsu.MovieApp.Common.DomainModel;
using System.Collections.Generic;

namespace Fujitsu.MovieApp.Common.Interfaces
{
    public interface IMovieRepository
    {
        string Create(Movie movie);
        Movie Retrieve(string id);
        IEnumerable<Movie> RetrieveAll();
        void Update(Movie movie);
        void Delete(string id);
    }
}
