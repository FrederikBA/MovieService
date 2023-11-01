using MovieRental.Web.Model.Dto;

namespace MovieRental.Web.Interface.DomainService;

public interface IRentalService
{
    Task RentMovies(List<MovieDto> movies);
}