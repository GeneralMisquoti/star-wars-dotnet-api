using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NodaTime;

namespace PL_452490_P2.Models
{
    [XmlRoot("Movie")]
    public class Movie
    {
        public int Id { get; set; }
#nullable enable
        [Range(0, ulong.MaxValue)]
        public uint ChronologicalOrderId { get; set; }
        public uint TmdbId { get; set; }
        public string? Name { get; set; }
        
        [DataType(DataType.Date)]
        public LocalDate? ReleaseDate { get; set; }
        public ulong? Budget { get; set; }
        public ulong? BoxOffice { get; set; }
        public ICollection<ActorPerMovie>? ActorsPerMovies { get; set; }
#nullable disable
        
    }
}