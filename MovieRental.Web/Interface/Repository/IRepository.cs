using Ardalis.Specification;

namespace MovieRental.Web.Interface.Repository;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
    
}