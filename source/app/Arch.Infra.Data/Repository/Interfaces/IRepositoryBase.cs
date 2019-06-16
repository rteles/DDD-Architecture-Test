namespace Arch.Infra.Data.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> : Core.Interfaces.Repository.IRepositoryBase<TEntity> where TEntity : class
    {
    }
}