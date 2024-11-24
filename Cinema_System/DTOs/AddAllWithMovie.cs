using Cinema_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Cinema_System.DTOs
{
    public class AddAllWithMovie
    {
        [Required]
        public string Title { get; set; }
        public DateTime ReleasYear { get; set; }
        public CategoryDto categoryDto { get; set; }
        public CinemaDto cinemaDto { get; set; }
    }
}
