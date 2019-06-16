namespace Arch.Core.Interfaces.Repository.ReadOnly
{
    public interface IReadOnlyRepositoryBase<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        System.Collections.Generic.IEnumerable<TEntity> GetAll();
        System.Collections.Generic.IEnumerable<TEntity> GetAll(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> filter);
    }
}