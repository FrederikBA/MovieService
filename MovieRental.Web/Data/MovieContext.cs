using Microsoft.EntityFrameworkCore;
using MovieRental.Web.Model;

namespace MovieRental.Web.Data;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; } = null!;
    
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
        
    }
}