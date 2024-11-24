using Cinema_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Cinema_System.DTOs
{
    public class AddAllWithCinema
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Placeholder { get; set; }
        public List<MovieDto> movieDtos { get; set; }
    }
}
