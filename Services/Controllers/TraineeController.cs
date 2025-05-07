using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTOs;
using SharedLibrary.Models;
using Services.Repos;


namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly IGenericRepo<Trainee> _traineeRepo;
        private readonly IGenericRepo<Track> _trackRepo;


        public TraineeController(IGenericRepo<Trainee> traineeRepo, IGenericRepo<Track> trackRepo)
        {
            _traineeRepo = traineeRepo;
            _trackRepo = trackRepo;
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var trainees = _traineeRepo.GetAll();

            if (!trainees.Any())
                return NotFound("No trainees found.");

            return Ok(trainees.Select(trainee => new TraineeDTO(trainee)).ToList());
        }


        [HttpGet("GetByID/{id:int}")]
        public IActionResult GetByID(int id)
        {
            var trainee = _traineeRepo.GetById(id);

            if (trainee == null)
                return NotFound($"Trainee with ID {id} not found.");

            return Ok(new TraineeDTO(trainee));
        }


        [HttpPost("Add")]
        public IActionResult Add(Trainee trainee)
        {
            if (trainee == null)
                return BadRequest("Trainee cannot be null.");


            var Tracks = _trackRepo.GetAll().Select(t => t.Id);

            if (!Tracks.Any(t => t == trainee.TrackID))
                return NotFound($"Track with ID {trainee?.TrackID} not found.");


            _traineeRepo.Add(trainee);
            return CreatedAtAction(nameof(GetByID), new { id = trainee.Id }, new TraineeDTO(trainee));
        }


        [HttpPut("Edit")]
        public IActionResult Edit(Trainee trainee)
        {
            var Tracks = _trackRepo.GetAll().Select(t => t.Id);
            
            if (!Tracks.Any(t => t == trainee.TrackID))
                return NotFound($"Track with ID {trainee?.TrackID} not found.");

            try
            {
                _traineeRepo.Update(trainee);
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var trainee = _traineeRepo.GetById(id);

            if (trainee == null)
                return NotFound($"Trainee with ID {id} not found.");

            _traineeRepo.Delete(trainee);
            return Ok("Deleted Successfully");
        }

    }
}
