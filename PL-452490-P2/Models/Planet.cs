namespace PL_452490_P2.Models
{
    public class Planet
    {
        
        public int Id { get; set; }
        #nullable enable
        public string? Name { get; set; }
        public uint? NumSuns { get; set; }
        public uint? NumMoons { get; set; }
        public ulong? Population { get; set; }
        #nullable disable
    }
}