using FluentValidation;

namespace TesteCQRS.Application.Queries.Customer.Validators
{
    public class CustomerFindByIdQueryValidator: AbstractValidator<CustomerFindByIdQuery>
    {
        public CustomerFindByIdQueryValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().WithMessage("Id é Obrigatório");
        }
    }
}
