namespace PL_452490_P2.Models
{
    /// <summary>
    ///  Required to be able to track who (<see cref="FightGroup"/>)
    ///  dealt a Blow with which <see cref="Weapon"/>,
    ///  who they hurt, and how much <see cref="DamageDealt"/>.
    ///  </summary>
    ///
    /// 
    ///  Using <see cref="FightGroup"/> in <see cref="Blower"/>
    ///  and <see cref="Blown"/> to be able to have two people
    ///  deal a blow with the same weapon at the same time, or
    ///  multiple people getting hit at the same time
    ///  (e.g. Death Star explosion).
    /// 
    ///  Unlikely, but possible.
    ///  This choice requires having a variety of subsets of
    ///  <see cref="FightGroup"/>s for each <see cref="Fight"/>
    ///  even if in the fight there never were two people dealing
    ///  two blows with the same <see cref="Weapon"/>
    ///  at the same time.
    public class Blow
    {
        public int Id { get; set; }
        public FightGroup Blowers { get; set; }
        public int BlowersId { get; set; }
        public FightGroup Blowees { get; set; }
        public int BloweesId { get; set; }
#nullable enable
        public uint? BlowOrderInFight { get; set; }
        public Weapon? WithWeapon { get; set; }
        public int? WithWeaponId { get; set; }
        public uint? DamageDealt { get; set; }
        public Fight? InFight { get; set; }
        public int? InFightId { get; set; }
    }
}