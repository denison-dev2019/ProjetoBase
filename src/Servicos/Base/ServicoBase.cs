using AutoMapper;
using Crosscutting.Notificacoes;
using Crosscutting.Utilitarios;
using Dominio.Interfaces.Repositorios.Base;
using Dominio.Interfaces.Servicos.Base;
using Dominio.Interfaces.Uow;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Base
{
    public class ServicoBase<T> : IServicoBase<T> where T : class, new()
    {
        protected readonly INotificador _notificador;
        protected IMapper _mapper { get; set; }
        protected IUnitOfWork _unitOfWork { get; set; }
        protected readonly IRepositorio<T> _repositorio;
        public ServicoBase(IServiceProvider serviceProvider, IRepositorio<T> repositorio =null)
        {
            _notificador = (INotificador)serviceProvider.GetService(typeof(INotificador));
            _unitOfWork = (IUnitOfWork)serviceProvider.GetService(typeof(IUnitOfWork));
            _mapper = (IMapper)serviceProvider.GetService(typeof(IMapper));
            _repositorio = repositorio;

        }
        public Expression<Func<T1, bool>> Condicao<T1>(Expression<Func<T1, bool>> expressao) => expressao;

        public Expression<Func<T1, bool>> Condicao<T1>() => null;

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            if (entidade is null)
            {
                Notificar("Dados inválidos.");
                return false;
            }
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;
            Notificar(validator);
            return false;
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                Notificar(error.ErrorMessage);
        }
        protected void Notificar(string mensagem) => _notificador.Handle(new Notificacao(mensagem));

        protected async Task<bool> AdicionarAsync(T entity)
        {
            _unitOfWork.BeginTransaction();
            await _repositorio.AdicionarAsync(entity);
            _unitOfWork.CommitTransaction();
            _unitOfWork.SaveChanges();
            return true;
        }

        protected async Task<bool> AtualizarAsync(int id, T entity)
        {
            _unitOfWork.BeginTransaction();
            if (await _repositorio.ObterPorId(id) == null)
            {
                Notificar(ValidationMessage.RegistroNaoEncontrado);
                return false;
            }
            await _repositorio.AtualizarAsync(entity);
            _unitOfWork.CommitTransaction();
            _unitOfWork.SaveChanges();
            return true;
        }

        protected async Task<bool> DeleteAsync(int id)
        {
          //  await _repositorio.RemoverAsync(id);
          //  _unitOfWork.SaveChanges();
            return true;
        }
    }
}
