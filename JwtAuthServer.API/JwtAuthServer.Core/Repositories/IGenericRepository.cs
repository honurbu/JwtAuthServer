using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthServer.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(int id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);       
        //Where koşulu sağlanabilmesi için ifade olarak fonkisoyn parametreli TEntity alan ve bool
        //dönen fonksiyonu gir demek.
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);

    }
}
