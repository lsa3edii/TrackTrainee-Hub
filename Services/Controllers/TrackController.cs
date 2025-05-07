using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using Services.Repos;
using SharedLibrary.DTOs;


namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllUsers")]
    public class TrackController : ControllerBase
    {
        private readonly IGenericRepo<Track> _trackRepo;

        public TrackController(IGenericRepo<Track> trackRepo)
        {
            _trackRepo = trackRepo;
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var tracks = _trackRepo.GetAll();

            if (!tracks.Any())
                return NotFound("No tracks found.");

            return Ok(tracks.Select(track => new TrackDTO(track)));
        }


        [HttpGet("GetByID/{id:int}")]
        public IActionResult GetByID(int id)
        {
            var track = _trackRepo.GetById(id);

            if (track == null)
                return NotFound($"Track with ID {id} not found.");

            return Ok(new TrackDTO(track));
        }


        [HttpPost("Add")]
        public IActionResult Add(Track track)
        {
            if (track == null)
                return BadRequest("Track cannot be null.");

            _trackRepo.Add(track);
            return CreatedAtAction(nameof(GetByID), new { id = track.Id }, track);
        }


        [HttpPut("Edit")]
        public IActionResult Edit(Track track)
        {
            if (track == null)
                return BadRequest("Track cannot be null.");

            try
            {
                _trackRepo.Update(track);
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                //return BadRequest($"Error: {ex.Message}");
                return NotFound($"Track with ID {track?.Id} not found.");
            }
        }
        

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var track = _trackRepo.GetById(id);

            if (track == null)
                return NotFound($"Track with ID {id} not found.");

            _trackRepo.Delete(track);
            return Ok("Deleted Successfully");
        }

    }
}
