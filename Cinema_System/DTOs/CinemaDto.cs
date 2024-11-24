using Cinema_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Cinema_System.DTOs
{
    public class CinemaDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Placeholder { get; set; }
    }
}
