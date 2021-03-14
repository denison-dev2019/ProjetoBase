using Dominio.Dtos.Cadastro;
using Dominio.Interfaces.Servicos.Cadastro;
using Servicos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Cadastro
{
    public class ClienteServico: ServicoBase<ClienteDTO>, IClienteServico
    {
        public ClienteServico(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

        public async Task<ClienteDTO> ObterPorId(int id)
        {
            return _mapper.Map<ClienteDTO>(await _unitOfWork.Cliente.ObterPorId(id));
        }
    }
}
