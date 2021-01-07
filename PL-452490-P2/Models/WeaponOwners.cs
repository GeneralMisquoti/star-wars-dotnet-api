namespace PL_452490_P2.Models
{
    /** Required to track the change of ownership of a specific
     *  weapon over time.
     */
    public class WeaponOwners
    {
        public int Id { get; set; }
        public uint WeaponOwnerOrder { get; set; }
        public Person Owner { get; set; }
        public int OwnerId { get; set; }
        public Weapon Weapon { get; set; }
        public int WeaponId { get; set; }
    }
}