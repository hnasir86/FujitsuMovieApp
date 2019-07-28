using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fujitsu.MovieApp.Common.DomainModel
{
    public class Movie
    {

        public string id { get; set; }
        public string title { get; set; }
        public string director { get; set; }
        public string actors { get; set; }
        public string image { get; set; }
        public int year { get; set; }
    }
}
