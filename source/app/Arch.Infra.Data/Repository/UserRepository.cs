using Arch.Core.Entities;
using Arch.Infra.Data.Repository.Interfaces.ReadOnly;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Data.SqlClient;
using Dapper;
using DapperExtensions;

namespace Arch.Infra.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, Core.Interfaces.Repository.IUserRepository
    {
        public IEnumerable<User> GetActiveUsers()
        {
            var lstActiveUsers = from u in db.User
                                 where u.Active == true
                                 select u;

            return lstActiveUsers;
        }

        public IEnumerable<User> GetAll()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var users = conn.Query<User>(@"SELECT 
                                                    [Id]
                                                   ,[Name]
                                                   ,[LastName]
                                                   ,[BirthDate]
                                                   ,[Email]
                                                   ,[Active] 
                                               FROM 
                                                   [dbo].[User]");

                return users;
            }
        }

        public IEnumerable<User> GetAll(Expression<Func<User, bool>> filter)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var users = conn.GetList<User>(filter);
                return users;
            }
        }

        public User GetById(int id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var query = String.Concat(@"SELECT 
                                                 [Id]
                                                ,[Name]
                                                ,[LastName]
                                                ,[BirthDate]
                                                ,[Email]
                                                ,[Active] 
                                            FROM 
                                                [dbo].[User] 
                                            WHERE 
                                                [Id] = {0}", id);

                var users = conn.Get<User>(query);

                return users;
            }
        }
    }
}