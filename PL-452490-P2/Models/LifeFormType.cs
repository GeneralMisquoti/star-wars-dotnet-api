namespace PL_452490_P2.Models
{
    public class LifeFormType
    {
        public int Id { get; set; }
#nullable enable
        public AbstractLifeFormType? AbstractLifeFormType { get; set; }
        public int? AbstractLifeFormTypeId { get; set; }
        public string? Name { get; set; }
    }
}