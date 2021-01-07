using System.Collections.Generic;

namespace PL_452490_P2.Models
{
    /// <summary>
    /// Required because <see cref="Person"/>s can
    /// change sides mid-<see cref="Fight"/>.
    /// </summary>
    public class FightStage
    {
        public enum FightResult
        {
            Unknown,
            FirstWon,
            SecondWon,
            Unfinished
        }
        
        public int Id { get; set; }
        public FightGroup FirstGroup { get; set; }
        public int FirstGroupId { get; set; }
        public FightGroup SecondGroup { get; set; }
        public int SecondGroupId { get; set; }
        public ICollection<Blow> Blows { get; set; }
        
        public FightResult Result { get; set; }
        public int ResultId { get; set; }
    }
}