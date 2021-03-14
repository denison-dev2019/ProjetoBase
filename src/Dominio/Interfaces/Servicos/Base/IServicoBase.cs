using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dominio.Interfaces.Servicos.Base
{
    public interface IServicoBase<T>
    {
        Expression<Func<T, bool>> Condicao<T>(Expression<Func<T, bool>> expressao);
        Expression<Func<T, bool>> Condicao<T>();
    }
}
