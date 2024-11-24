using Cinema_System.DTOs;

namespace Cinema_System.Repository.CinemaRepository
{
    public interface ICinema
    {
        public void Add(AddAllWithCinema addAllWithCinema);
        public List<AddAllWithCinema> GetAll();
        public void Update(AddAllWithCinema addAllWithCinema, int id);
    }
}
