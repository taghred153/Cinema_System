using Cinema_System.DTOs;
using Cinema_System.Repository.MovieRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo _repo;

        public MovieController(IMovieRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("AddAll")]
        public IActionResult AddAll(AddAllWithMovie addAllWithMovie)
        {
            _repo.AddAll(addAllWithMovie);
            return Ok();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var res = _repo.GetAll();
            return Ok(res);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var res = _repo.GetById(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
