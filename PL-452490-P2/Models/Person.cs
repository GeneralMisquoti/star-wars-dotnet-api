using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PL_452490_P2.Models
{
    // [DataContract]
    public class Person
    {
        public enum ForceUserType
        {
            Unknown,
            None,
            Sensitive,
            Jedi,
            Sith,
        }
    
        // [DataMember]
        [Key]
        public int Id { get; set; }
        #nullable enable
        // [DataMember]
        public string? Name { get; set; }
        
        [Column(TypeName="VARCHAR(24)")]
        [EnumDataType(typeof(ForceUserType))]
        [JsonConverter(typeof(StringEnumConverter))]
        // [DataMember]
        public ForceUserType? ForceType {get; set; }
        
        [Range(0, UInt64.MaxValue)]
        // [DataMember]
        public uint? MidichlorianCount { get; set; }
        public Planet? FromPlanet { get; set; }
        // [DataMember]
        public int? FromPlanetId { get; set; }
        public ICollection<ActorPerMovie>? ActorPerMovies { get; set; }
        
        [JsonIgnore]
        // [IgnoreDataMember]
        public Person? Master { get; set; }
        // [DataMember]
        public int? MasterId { get; set; }
        [JsonIgnore]
        // [IgnoreDataMember]
        public Person? Apprentice { get; set; }
        // [DataMember]
        public int? ApprenticeId { get; set; }
        public ICollection<FightGroup>? InFightGroups { get; set; }
        public LifeFormType? LfType { get; set; }
        // [DataMember]
        public int? LfTypeId { get; set; }
        #nullable disable
        
    }
}