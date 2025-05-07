using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace Services.Context
{
    public class TrackTraineeContext : DbContext
    {
        public TrackTraineeContext(DbContextOptions<TrackTraineeContext> options) 
            : base(options) { }


        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
       
    }

}
