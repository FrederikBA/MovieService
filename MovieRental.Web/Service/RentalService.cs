using MovieRental.Web.Exceptions;
using MovieRental.Web.Interface.DomainService;
using MovieRental.Web.Model.Dto;
using MovieRental.Web.Producer;

namespace MovieRental.Web.Service;

public class RentalService : IRentalService
{
    private readonly KafkaProducer _kafkaProducer;
    private readonly IMovieService _movieService;

    public RentalService(KafkaProducer kafkaProducer, IMovieService movieService)
    {
        _kafkaProducer = kafkaProducer;
        _movieService = movieService;
    }

    public async Task RentMovies(List<MovieDto> movies)
    {
        var movieCatalogue = await _movieService.GetMovies();

        var selectedMovies = movieCatalogue
            .Where(movie => movies.Any(m => m.Id == movie.Id))
            .ToList();

        if (selectedMovies.Any())
        {
            await _kafkaProducer.ProduceAsync("create_movie_order", selectedMovies);
        }
        else
        {
            throw new MoviesNotFoundException();
        }
    }
}