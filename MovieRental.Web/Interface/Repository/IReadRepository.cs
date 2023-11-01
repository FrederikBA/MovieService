using Ardalis.Specification;

namespace MovieRental.Web.Interface.Repository;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
    
}