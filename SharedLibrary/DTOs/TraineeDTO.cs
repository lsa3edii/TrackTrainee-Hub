using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.DTOs
{
    public class TraineeDTO
    {
        public TraineeDTO() { }

        public TraineeDTO(Trainee trainee)
        {
            Id = trainee.Id;
            Name = trainee.Name;
            Gender = trainee.Gender;
            Email = trainee.Email;
            Mobile = trainee.Mobile;
            Birthdate = trainee.Birthdate;
            IsGraduated = trainee.IsGraduated;

            TrackID = trainee.TrackID;
            Track = trainee.Track?.Name;
        }


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime Birthdate { get; set; } = new DateTime(2000, 1, 1);
        public bool IsGraduated { get; set; }

        public int? TrackID { get; set; }
        public string? Track { get; set; }
    }
}
