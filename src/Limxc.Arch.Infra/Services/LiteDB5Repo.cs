using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using Limxc.Arch.Core.Shared.Domains;
using Limxc.Arch.Core.Shared.Interfaces;
using LiteDB;

namespace HDP.Infra.Services
{
    public class LiteDB5Repo<TId, T> : IRepo<TId, T> where T : IEntity<TId>
    {
        private readonly string _connStr;

        public LiteDB5Repo(string folder)
        {
            _connStr = $@"Filename={Path.Combine(folder, typeof(T).Name)}"; // ;Connection=shared
        }

        public T Save(T entity)
        {
            using (var repo = new LiteRepository(_connStr))
            {
                if (entity is IAuditable abe)
                {
                    if (entity.Id.Equals(default(TId)))
                        abe.Created = DateTime.Now;
                    else
                        abe.LastModified = DateTime.Now;
                }

                repo.Upsert(entity);
                return entity;
            }
        }

        public void SaveChanges(T[] entities)
        {
            using (var repo = new LiteRepository(_connStr))
            {
                foreach (var entity in entities)
                    if (entity is IAuditable abe)
                    {
                        if (entity.Id.Equals(default(TId)))
                            abe.Created = DateTime.Now;
                        else
                            abe.LastModified = DateTime.Now;
                    }

                repo.Upsert(entities);
            }
        }

        public int Delete(Expression<Func<T, bool>> predicate)
        {
            using (var repo = new LiteRepository(_connStr))
            {
                return repo.DeleteMany(predicate);
            }
        }

        public bool DeleteById(TId id)
        {
            using (var repo = new LiteRepository(_connStr))
            {
                var rtn = repo.Delete<T>(new BsonValue(id));
                return rtn;
            }
        }

        public bool Delete(T entity)
        {
            using (var repo = new LiteRepository(_connStr))
            {
                var rtn = repo.Delete<T>(new BsonValue(entity.Id));
                return rtn;
            }
        }

        public T FindById(TId id)
        {
            using (var repo = new LiteRepository(_connStr))
            {
                return repo.SingleById<T>(new BsonValue(id));
            }
        }

        public IList<T> Find(Expression<Func<T, bool>> predicate)
        {
            using (var repo = new LiteRepository(_connStr))
            {
                return repo.Fetch(predicate);
            }
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            using (var db = new LiteDatabase(_connStr))
            {
                var col = db.GetCollection<T>();

                return col.Count(predicate);
            }
        }

        public IList<T> PageFind<TK>(Expression<Func<T, bool>> predicate, Expression<Func<T, TK>> descendingBy,
            int pageNum, int pageSize, out int pageCount)
        {
            using (var db = new LiteDatabase(_connStr))
            {
                var col = db.GetCollection<T>();

                var count = col.Count(predicate);
                pageCount = (int)Math.Ceiling(count / (float)pageSize);
                var rst = col.Query().Where(predicate).OrderByDescending(descendingBy).Skip(pageNum - 1).Limit(pageSize)
                    .ToList();
                return rst;
            }
        }

        public void EnsureIndex<TK>(Expression<Func<T, TK>> keySelector)
        {
            using (var repo = new LiteRepository(_connStr))
            {
                repo.EnsureIndex(keySelector);
            }
        }
    }

    public class LiteDB5Repo<T> : LiteDB5Repo<Guid, T>, IRepo<T> where T : IEntity<Guid>
    {
        public LiteDB5Repo(string folder) : base(folder)
        {
        }
    }
}