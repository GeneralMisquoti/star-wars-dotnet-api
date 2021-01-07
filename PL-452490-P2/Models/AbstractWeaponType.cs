using System.Collections.Generic;

namespace PL_452490_P2.Models
{
    /// <summary>
    /// Required to be able to know that, e.g. all lightsabers belong
    /// to the same abstract light saber type.
    /// </summary>
    public class AbstractWeaponType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Weapon> WeaponsOfType { get; set; }
        public ICollection<Person> UsedBy { get; set; }
        public ICollection<Blow> InBlows { get; set; }
    }
}