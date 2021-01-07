using System.Collections.Generic;

namespace PL_452490_P2.Models
{
    /// <summary>
    /// We can see which
    /// <see cref="Person">Person</see>
    /// the Weapon belongs to
    /// </summary>
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AbstractWeaponType WeaponType { get; set; }
        public int WeaponTypeId { get; set; }
        public ICollection<WeaponOwners> WeaponOwners { get; set; }
    }
}