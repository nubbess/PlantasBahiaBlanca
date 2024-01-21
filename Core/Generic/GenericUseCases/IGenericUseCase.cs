using System.Linq.Expressions;

namespace Core.Generic.GenericUseCases
{
    interface IGenericUseCase <T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null!, bool tracked = true);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null!);

        Task Register(T obj);

        Task Delete(T obj);

        Task Update(T obj);
    }
}
