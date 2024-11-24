using Cinema_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Cinema_System.DTOs
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
