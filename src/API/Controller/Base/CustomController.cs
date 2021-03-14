using Crosscutting.Enuns;
using Crosscutting.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILoja.Controllers.Base
{
    [ApiController]
    public class CustomController : ControllerBase
    {
        private readonly INotificador _notificador;
        protected bool UsuarioAutenticado { get; set; }

        protected CustomController(IServiceProvider serviceProvider)
        {
            _notificador = (INotificador)serviceProvider.GetService(typeof(INotificador));
        }
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse<T>(T result = default, 
            EnumStatusResponseApi statusResponse = EnumStatusResponseApi.Ok)
        {
            if (OperacaoValida())
            {
                return statusResponse switch
                {
                    EnumStatusResponseApi.Created => StatusCode(201, new { success = true, data = result }),
                    EnumStatusResponseApi.NotFound => StatusCode(404, new { success = true }),
                    EnumStatusResponseApi.NoContent => NoContent(),
                    _ => Ok(new { Success = true, Data = result })
                };
            }

            return Ok(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }
        protected ActionResult CustomResponse(EnumStatusResponseApi statusResponse = EnumStatusResponseApi.Ok)
        {
            return CustomResponse((object)null, statusResponse);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                Notificar(errorMsg);
            }
        }
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
