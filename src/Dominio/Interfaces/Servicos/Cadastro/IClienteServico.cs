using Dominio.Dtos.Cadastro;
using Dominio.Interfaces.Servicos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Servicos.Cadastro
{
    public interface IClienteServico: IServicoBase<ClienteDTO>
    {
        Task<ClienteDTO> ObterPorId(int id);
    }
}
