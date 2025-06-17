using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Limxc.Arch.Core.Shared.Domains;

namespace Limxc.Arch.Core.Shared.Interfaces
{
    public interface IRepo<in TId, T>
        where T : IEntity<TId>
    {
        T Save(T entity);

        void SaveChanges(T[] entities);

        int Delete(Expression<Func<T, bool>> predicate);

        bool DeleteById(TId id);

        bool Delete(T entity);

        T FindById(TId id);

        IList<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///     分页查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="descendingBy"></param>
        /// <param name="pageNum">1~n</param>
        /// <param name="pageSize">1~n</param>
        /// <param name="pageCount">0~n</param>
        /// <returns></returns>
        IList<T> PageFind<TK>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TK>> descendingBy,
            int pageNum,
            int pageSize,
            out int pageCount
        );

        int Count(Expression<Func<T, bool>> predicate);
    }

    public interface IRepo<T> : IRepo<Guid, T>
        where T : IEntity<Guid> { }
}
