using Ardalis.Specification.EntityFrameworkCore;
using MovieRental.Web.Interface.Repository;

namespace MovieRental.Web.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
{
    public readonly MovieContext MovieContext;

    public EfRepository(MovieContext movieContext) : base(movieContext) =>
        this.MovieContext = movieContext;
}