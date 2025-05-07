using Services.Context;
using SharedLibrary.Models;
using Services.Repos;
using Microsoft.EntityFrameworkCore;

namespace Services.BL
{
    public class TrackBL : IGenericRepo<Track>
    {
        private readonly TrackTraineeContext _context;

        public TrackBL(TrackTraineeContext context)
        {
            _context = context;
        }



        public IEnumerable<Track> GetAll()
        {
            return _context.Tracks.Include(t => t.Trainees)
                .ToList();
        }


        public Track? GetById(int id)
        {
            return _context.Tracks.Include(t => t.Trainees)
                .FirstOrDefault(t => t.Id == id);
        }


        public void Add(Track entity)
        {
            if (entity != null)
            {
                _context.Tracks.Add(entity);
                _context.SaveChanges();
            }
        }


        public void Update(Track entity)
        {
            if (entity != null)
            {
                _context.Tracks.Update(entity);
                _context.SaveChanges();
            }
        }


        public void Delete(Track entity)
        {
            if (GetAll().Any(e => e.Id == entity.Id))
            {
                _context.Tracks.Remove(entity);
                _context.SaveChanges();
            }
        }

    }
}
