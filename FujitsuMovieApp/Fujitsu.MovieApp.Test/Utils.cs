using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.MovieApp.Test
{
    public class Utils
    {
        public static string GetConnectionStringForMongoDB()
        {
            return "mongodb+srv://service:rSSCDZTIZzwPRsnEHGvY@cluster0-iv5oy.mongodb.net/movie?retryWrites=true";

        }
    }
}
