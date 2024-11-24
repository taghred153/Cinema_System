using System.ComponentModel.DataAnnotations;

namespace Cinema_System.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime ReleasYear { get; set; }
        public Category Category { get; set; }
        public Cinema cinema { get; set; }
    }
}
