using Microsoft.EntityFrameworkCore;
using Services.Context;
using Services.Repos;
using SharedLibrary.Models;

namespace Services.BL
{
    public class TraineeBL : IGenericRepo<Trainee>
    {
        private readonly TrackTraineeContext _context;

        public TraineeBL(TrackTraineeContext context)
        {
            _context = context;
        }



        public IEnumerable<Trainee> GetAll()
        {
            return _context.Trainees.Include(t => t.Track)
                .ToList();
        }


        public Trainee? GetById(int id)
        {
            return _context.Trainees.Include(t => t.Track)
                .FirstOrDefault(t => t.Id == id);
        }


        public void Add(Trainee entity)
        {
            if (entity.TrackID.HasValue)
                entity.Track = _context.Tracks.Find(entity.TrackID.Value);

            if (entity != null)
            {
                _context.Trainees.Add(entity);
                _context.SaveChanges();
            }
        }


        public void Update(Trainee entity)
        {
            //if (entity != null)
            //{
            //    _context.Trainees.Update(entity);
            //    _context.SaveChanges();
            //}

            var existingTrainee = _context.Trainees.FirstOrDefault(t => t.Id == entity.Id);

            if (existingTrainee == null)
                throw new Exception("Trainee not found");

            _context.Entry(existingTrainee).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }


        public void Delete(Trainee entity)
        {
            if (GetAll().Any(e => e.Id == entity.Id))
            {
                _context.Trainees.Remove(entity);
                _context.SaveChanges();
            }
        }

    }
}
