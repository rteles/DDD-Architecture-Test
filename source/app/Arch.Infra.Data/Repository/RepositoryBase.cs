﻿using Arch.Infra.Common.IoC;
using Arch.Infra.Data.Context;
using Arch.Infra.Data.Repository.Interfaces;
using System;
using System.Configuration;
using System.Data.Entity;

namespace Arch.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ArchContext db
        {
            get
            {
                return AppContext.GetOrRegister<ArchContext>();
            }
        }

        protected static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ArchContext"].ConnectionString;
            }
        }

        public void Add(TEntity obj)
        {
            #region
            //var transaction = db.Database.BeginTransaction();

            //try
            //{
            //    transaction.Commit();
            //}            
            //catch (Exception ex)
            //{
            //    transaction.Rollback();
            //    throw ex;
            //}
            //finally
            //{
            //    transaction.Dispose();
            //}
            #endregion

            db.Set<TEntity>().Add(obj);
            db.SaveChanges();
        }

        //public TEntity GetById(int id)
        //{
        //    return db.Set<TEntity>().Find(id);
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return db.Set<TEntity>().ToList();
        //}

        //public IEnumerable<TEntity> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        //{
        //    return db.Set<TEntity>().Where(filter);
        //}

        public void Update(TEntity obj)
        {
            //var transaction = db.Database.BeginTransaction();

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            db.Dispose();
            
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}