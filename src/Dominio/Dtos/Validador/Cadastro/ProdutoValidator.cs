using Crosscutting.Utilitarios;
using Dominio.Dtos.Cadastro;
using FluentValidation;

namespace Dominio.DTO.Validador.Cadastro
{
    public class ProdutoValidator: AbstractValidator<ProdutoDTO>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome).NotEmpty().WithMessage(ValidationMessage.NotNullGeneric)
                .MaximumLength(100).WithMessage(ValidationMessage.MaxLengthGeneric);
            RuleFor(p => p.Preco).NotNull()
                .WithMessage(ValidationMessage.NotNullGeneric);
        }
    }
}
