using Cinema_System.DTOs;
using Cinema_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_System.Repository.MovieRepository
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AppDbContext _context;

        public MovieRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddAll(AddAllWithMovie addAllWithMovie)
        {
            Movie movie = new Movie
            {
                Title = addAllWithMovie.Title,
                ReleasYear = addAllWithMovie.ReleasYear,
                Category = new Category
                {
                    Name = addAllWithMovie.categoryDto.Name,
                },
                cinema = new Cinema
                {
                    Name = addAllWithMovie.cinemaDto.Name,
                    Placeholder = addAllWithMovie.cinemaDto.Placeholder,
                }
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public List<AddAllWithMovie> GetAll()
        {
            var res = _context.Movies
                .Include(x => x.Category)
                .Include(x => x.cinema)
                .Select(x => new AddAllWithMovie
                {
                    Title = x.Title,
                    ReleasYear = x.ReleasYear,
                    categoryDto = new CategoryDto
                    {
                        Name = x.Category.Name
                    },
                    cinemaDto = new CinemaDto
                    {
                        Name = x.cinema.Name,
                        Placeholder = x.cinema.Placeholder,
                    }
                }).ToList();
            return res;
        }
        public AddAllWithMovie GetById(int id)
        {
            var res = _context.Movies
                .Include(x => x.Category)
                .Include(x => x.cinema)
                .FirstOrDefault(x => x.Id == id);
            if(res != null)
            {
                return new AddAllWithMovie
                {
                    Title = res.Title,
                    ReleasYear = res.ReleasYear,
                    categoryDto = new CategoryDto
                    {
                        Name = res.Category.Name,
                    },
                    cinemaDto = new CinemaDto
                    {
                        Name = res.cinema.Name,
                        Placeholder = res.cinema.Placeholder,
                    }
                };
            }
            else
            {
                throw new Exception("Not Found");
            }
        }
    }
}
