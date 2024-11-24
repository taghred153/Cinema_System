using Cinema_System.DTOs;
using Cinema_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_System.Repository.CinemaRepository
{
    public class CinemaRepo : ICinema
    {
        private readonly AppDbContext _context;

        public CinemaRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(AddAllWithCinema addAllWithCinema)
        {
            Cinema cinema = new Cinema
            {
                Name = addAllWithCinema.Name,
                Placeholder = addAllWithCinema.Placeholder,
                Movies = addAllWithCinema.movieDtos.Select(x => new Movie
                {
                    Title = x.Title,
                    ReleasYear = x.ReleasYear,
                    Category = new Category
                    {
                        Name = x.categoryDto.Name,
                    }
                }).ToList(),
            };
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
        }

        public List<AddAllWithCinema> GetAll()
        {
            var res = _context.Cinemas
                .Include(x => x.Movies)
                .ThenInclude(x => x.Category)
                .Select(x  => new AddAllWithCinema
                {
                    Name = x.Name,
                    Placeholder = x.Placeholder,
                    movieDtos = x.Movies.Select(x => new MovieDto
                    {
                        Title = x.Title,
                        ReleasYear = x.ReleasYear,
                        categoryDto = new CategoryDto
                        {
                            Name = x.Category.Name,
                        }
                    }).ToList(),
                }).ToList();
            return res;
        }

        public void Update(AddAllWithCinema addAllWithCinema, int id)
        {
            var res = _context.Cinemas
                .Include(x => x.Movies)
                .ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
            if (res != null)
            {
                res.Name = addAllWithCinema.Name;
                res.Placeholder = addAllWithCinema.Placeholder;
                res.Movies = addAllWithCinema.movieDtos.Select(x => new Movie
                {
                    Title = x.Title,
                    ReleasYear = x.ReleasYear,
                    Category = new Category
                    {
                        Name = x.categoryDto.Name,
                    }
                }).ToList();
                _context.Cinemas.Update(res);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Not Found");
            }
        }
    }
}
