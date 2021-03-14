using Dominio.Dtos.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorios.Base
{
    public interface IRepositorio<T>: IDisposable
    {
        #region Entity
        Task<T> AdicionarAsync(T entidade);
        Task<T> AtualizarAsync(T entidade);
        Task<T> AtualizarAsync(T updated, int key);
        Task RemoverAsync(T entidade);
        Task RemoverAsync(int id);
        Task RemoverAsync(Expression<Func<T, bool>> query);
        Task<T> ObterPorId(int id);
        Task<IQueryable<T>> Obter(
                Expression<Func<T, bool>> filtro = null,
                PaginacaoDTO paginacao = null,
                params Expression<Func<T, object>>[] includes);
        Task<bool> ExisteAsync(Expression<Func<T, bool>> predicate);
        #endregion
    }
}
