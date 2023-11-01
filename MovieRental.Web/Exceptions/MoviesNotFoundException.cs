namespace MovieRental.Web.Exceptions;

public class MoviesNotFoundException : Exception
{
    public MoviesNotFoundException() : base("No movies found")
    {
    }
}