using MovieRental.Web.Model.Dto;

namespace MovieRental.Web.Interface.DomainService;

public interface IMovieService
{
    Task<MovieDto> GetMovieById(int id);
    Task<List<MovieDto>> GetMovies();
}