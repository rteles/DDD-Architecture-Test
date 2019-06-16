namespace Arch.Core.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        //TEntity GetById(int id);
        //System.Collections.Generic.IEnumerable<TEntity> GetAll();
        //System.Collections.Generic.IEnumerable<TEntity> GetAll(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> filter);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose(bool disposing);
    }
}