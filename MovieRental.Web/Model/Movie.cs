using System.ComponentModel.DataAnnotations;

namespace MovieRental.Web.Model;

public class Movie
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
}