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
        /// <summary>
        /// Entity framework test
        /// </summary>
        /// <param name="onlyActive"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUsers(bool onlyActive)
        {
            var lstActiveUsers = from u in db.User
                                 where (!onlyActive || u.Active == true)
                                 select u;

            return lstActiveUsers;
        }

        /// <summary>
        /// Dapper Test
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Dapper Test
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<User> GetAll(Expression<Func<User, bool>> filter)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var users = conn.GetList<User>(filter);
                return users;
            }
        }

        /// <summary>
        /// Dapper Test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var users = conn.Get<User>(id);
                return users;
            }
        }
    }
}