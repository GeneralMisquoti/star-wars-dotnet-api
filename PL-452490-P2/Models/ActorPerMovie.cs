namespace PL_452490_P2.Models
{
    /// <summary>
    /// Required because sometimes multiple actors may play the
    /// same character
    /// </summary>
    public class ActorPerMovie
    {
        public int Id { get; set; }
        public Movie InMovie { get; set; }
        public int InMovieId { get; set; }
        public Person Plays { get; set; }
        public int PlaysId { get; set; }
        public Actor PlayedBy { get; set; }
        public int PlayedById { get; set; }
    }
}