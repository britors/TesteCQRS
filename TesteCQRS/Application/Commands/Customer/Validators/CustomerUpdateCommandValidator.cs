using FluentValidation;

namespace TesteCQRS.Application.Commands.Customer.Validators
{
    public class CustomerUpdateCommandValidator : AbstractValidator<CustomerUpdateCommand>
    {
        public CustomerUpdateCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().WithMessage("Id é Obrigatório");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é Obrigatório");
            RuleFor(x => x.Name).MinimumLength(10).WithMessage("Nome deve ter pelo menos 10 caracteres");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email é Obrigatório");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email no formato inválido");
        }
    }
}
