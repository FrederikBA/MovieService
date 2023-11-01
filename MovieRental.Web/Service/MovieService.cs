using MovieRental.Web.Exceptions;
using MovieRental.Web.Interface.DomainService;
using MovieRental.Web.Interface.Repository;
using MovieRental.Web.Model;
using MovieRental.Web.Model.Dto;

namespace MovieRental.Web.Service;

public class MovieService : IMovieService
{
    private readonly IReadRepository<Movie> _readRepository;

    public MovieService(IReadRepository<Movie> readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<MovieDto> GetMovieById(int id)
    {
        var movie = await _readRepository.GetByIdAsync(id);

        if (movie == null) throw new MovieNotFoundException(id);
        var movieDto = new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
        };
        return movieDto;
    }


    public async Task<List<MovieDto>> GetMovies()
    {
        var movies = await _readRepository.ListAsync();
        var movieDtos = movies.Select(movie => new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
        }).ToList();
        return movieDtos;
    }
}