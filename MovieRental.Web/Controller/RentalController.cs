using Microsoft.AspNetCore.Mvc;
using MovieRental.Web.Interface.DomainService;
using MovieRental.Web.Model.Dto;

namespace MovieRental.Web.Controller;

[ApiController]
[Route("api/[controller]")]
public class RentalController : ControllerBase
{
    private readonly IRentalService _rentalService;

    public RentalController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }


    [HttpPost]
    public async Task<IActionResult> RentMovies(List<MovieDto> movies)
    {
        await _rentalService.RentMovies(movies);
        return Ok(movies);
    }
}