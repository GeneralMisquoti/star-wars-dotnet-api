using System.Collections.Generic;

namespace PL_452490_P2.Models
{
    public class Fight
    {
        
        public int Id { get; set; }
        public Movie InMovie { get; set; }
        public int InMovieId { get; set; }
        public ICollection<FightStage> Stages { get; set; }
    }
}