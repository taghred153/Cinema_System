using Cinema_System.DTOs;
using Cinema_System.Repository.CinemaRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinema _repo;

        public CinemaController(ICinema repo)
        {
            _repo = repo;
        }
        [HttpPost("Add")]
        public IActionResult Add(AddAllWithCinema addAllWithCinema)
        {
            _repo.Add(addAllWithCinema);
            return Ok();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var res = _repo.GetAll();
            return Ok(res);
        }
        [HttpPut("Update")]
        public IActionResult Update(AddAllWithCinema addAllWithCinema, int id)
        {
            try
            {
                _repo.Update(addAllWithCinema, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
