using Cinema_System.DTOs;

namespace Cinema_System.Repository.MovieRepository
{
    public interface IMovieRepo
    {
        public void AddAll(AddAllWithMovie addAllWithMovie);
        public List<AddAllWithMovie> GetAll();
        public AddAllWithMovie GetById(int id);
    }
}
