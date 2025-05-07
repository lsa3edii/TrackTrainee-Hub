using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Length must be bigger than 2 and lower than 10 chars.")]
        public string Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Trainee>? Trainees { get; set; } = new HashSet<Trainee>();
    }
}
