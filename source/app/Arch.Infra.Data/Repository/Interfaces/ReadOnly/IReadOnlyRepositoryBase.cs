namespace Arch.Infra.Data.Repository.Interfaces.ReadOnly
{
    public interface IReadOnlyRepositoryBase<TEntity> : Core.Interfaces.Repository.ReadOnly.IReadOnlyRepositoryBase<TEntity> where TEntity : class
    {
    }
}