using System.Collections.Generic;

namespace PL_452490_P2.Models
{
    /// <summary>
    /// Required because a <see cref="Fight"/> isn't always just between
    /// two <see cref="Person"/>s, but 2v1 and such combinations.
    /// </summary>
    public class FightGroup
    {
        public int Id { get; set; }
        public ICollection<Person> GroupMembers { get; set; }
#nullable enable
        public Fight? InFight { get; set; }
        public int? InFightId { get; set; }
    }
}