using System.Linq.Expressions;

namespace ASP_CRUD_Activity.Repositories
{
    public interface IBaseRepository<T>
    {
        //Task<T> GetAll(params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> Get(Guid id, params Expression<Func<T, object>>[] includes);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
    }
}
