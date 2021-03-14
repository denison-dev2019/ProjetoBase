namespace Dados.Repositorios.Base
{
    using Dominio.Dtos.Base;
    using Dominio.Interfaces.Repositorios.Base;
    using global::Dados.Contextos;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    namespace Dados.Repositorios
    {
        public abstract class Repositorio<T> : IDisposable, IRepositorio<T> where T : class, new()
        {
            protected readonly ProjetoBaseDbContext _db;
            protected readonly DbSet<T> _dbSet;

            public Repositorio(ProjetoBaseDbContext db)
            {
                _db = db;
                _db.dbConnection = _db.Database.GetDbConnection();
                _dbSet = db.Set<T>();
            }

            #region Métodos de CRUD (Entity Framework)

            public virtual async Task<T> AdicionarAsync(T entidade)
            {
                var result = await _dbSet.AddAsync(entidade);
                return result as T;
            }
            public virtual async Task<T> AtualizarAsync(T entidade)
            {
                await Task.Yield();
                _db.Set<T>().Update(entidade);
                return entidade;
            }
            public virtual async Task<T> AtualizarAsync(T updated, int key)
            {
                await Task.Yield();
                if (updated == null)
                    return null;

                T existing = _db.Set<T>().Find(key);
                if (existing != null)
                {
                    _db.Entry(existing).CurrentValues.SetValues(updated);
                }

                return existing;
            }
            

            public virtual async Task RemoverAsync(T entidade) => _db.Set<T>().Remove(entidade);
            
            public virtual async Task RemoverAsync(Expression<Func<T, bool>> query) => _db.Set<T>().RemoveRange(_dbSet.Where(query));

            public virtual async Task RemoverAsync(int id) => _db.Set<T>().Remove(await ObterPorId(id));


            #endregion

            #region Métodos de Busca (Entity Framework)

            public virtual async Task<T> ObterPorId(int id) => await _db.Set<T>().FindAsync(id);

            public virtual async Task<T> ObterPorId(params object[] ids) => await _db.Set<T>().FindAsync(ids);
            public virtual async Task<IQueryable<T>> Obter(Expression<Func<T, bool>> filtro = null,
                PaginacaoDTO paginacao = null,
                params Expression<Func<T, object>>[] includes)
            {

                var query = _dbSet.AsQueryable();

                if (filtro != null)
                    query = _dbSet.AsQueryable().Where(filtro);

                if (includes != null)
                {
                    foreach (var includeProperty in includes)
                    {
                        query = query.Include(includeProperty);
                    }

                }

                if (paginacao != null)
                {
                    query = _dbSet.AsQueryable().Skip((paginacao.PageNumber.Value - 1)
                        * paginacao.PageSize.Value).Take(paginacao.PageSize.Value);
                }
                return query.AsNoTracking();
            }

            #endregion

            public void Dispose()
            {
                _db?.Dispose();
                GC.SuppressFinalize(this);
            }

           
        }
    }

}
