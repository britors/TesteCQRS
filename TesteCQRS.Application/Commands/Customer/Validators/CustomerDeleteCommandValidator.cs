using FluentValidation;

namespace TesteCQRS.Application.Commands.Customer.Validators
{
    public class CustomerDeleteCommandValidator : AbstractValidator<CustomerDeleteCommand>
    {
        public CustomerDeleteCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id é Obrigatório");
        }
    }
}
