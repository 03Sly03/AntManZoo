using System.Linq.Expressions;

namespace AntManZooApi.Repositories
{
    public interface IRepository<TEntity>
    {
        // CRUD

        // Create

        Task<int> Add(TEntity entity);

        // Read

        Task<TEntity> GetById(int id);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAll();

        // Update

        Task<bool> Update(TEntity entity);

        // Delete

        Task<bool> Delete(int id);
    }
}
