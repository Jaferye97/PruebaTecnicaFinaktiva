using System.Linq.Expressions;

namespace ReporitorySqlServer.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity, TModel, in TPrimary>
    where TEntity : class
    where TModel : class
    {
        Task<TModel> GetAsync(TPrimary id);

        Task<List<TModel>> GetAllAsync();

        Task<List<TModel>> GetAllByIdAsync(IEnumerable<TPrimary> ids);

        Task<TEntity> Add(TModel model);

        Task<IEnumerable<TEntity>> Add(IEnumerable<TModel> models);

        Task<TEntity> Update(TModel model);

        void Update(IEnumerable<TModel> models);

        void Delete(TModel model);

        void Delete(IEnumerable<TModel> models);

        Task<List<TModel>> GetWithPredicateAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TModel>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TModel> GetUniqueAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
