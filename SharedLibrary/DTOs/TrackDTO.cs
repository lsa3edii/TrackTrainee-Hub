using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.DTOs
{
    public class TrackDTO
    {
        public TrackDTO() { }

        public TrackDTO(Track track)
        {
            Id = track.Id;
            Name = track.Name;
            Description = track.Description;
            Trainees = track.Trainees?.Select(t => t.Name).ToList();
        }


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<string>? Trainees { get; set; } = new HashSet<string>();
    }
}
