using System.Text.Json.Serialization;

namespace MovieRental.Web.Model.Dto;

public class MovieDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;
}