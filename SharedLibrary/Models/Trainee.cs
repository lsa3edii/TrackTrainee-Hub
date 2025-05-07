using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Length must be bigger than 3 and lower than 20 chars.")]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Invalid mobile number format.")]
        public string Mobile { get; set; }

        [Required]
        public DateTime Birthdate { get; set; } = new DateTime(2000, 1, 1);

        [Required]
        public bool IsGraduated { get; set; } = false;


        [ForeignKey(nameof(Track))]
        public int? TrackID { get; set; }
        public Track? Track { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

}
