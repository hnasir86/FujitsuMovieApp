using System;
using System.Collections.Generic;
using System.Text;

namespace Fujitsu.MovieApp.Common.Interfaces
{
    public interface IMovieRepository
    {
        void Create(Movie movie);
        Movie Retrieve(int id);
        void Update(Movie movie);
        void Delete(int id);
    }
}
