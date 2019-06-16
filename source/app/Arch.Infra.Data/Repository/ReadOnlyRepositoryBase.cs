using Arch.Infra.Data.Repository.Interfaces.ReadOnly;
using System.Configuration;

namespace Arch.Infra.Data.Repository
{
    public class ReadOnlyRepositoryBase<TEntity> : IReadOnlyRepositoryBase<TEntity> where TEntity : class
    {
        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ArchContext"].ConnectionString;
            }
        }

        //public TEntity GetById(int id)
        //{
        //var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ArchContext"].ToString());

        //throw new NotImplementedException();

        //using (var conn = new SqlConnection(ConnectionString))
        //{
        //    string query = "select bla...";

        //    conn.Execute(query)
        //}
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}
    }
}