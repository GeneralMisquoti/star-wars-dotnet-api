using System.Collections.Generic;

namespace PL_452490_P2.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Movie> InMovies { get; set; }
    }
}