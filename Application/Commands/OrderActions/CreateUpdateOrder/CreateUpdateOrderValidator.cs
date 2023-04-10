using FluentValidation;

namespace Application.Commands.OrderActions.CreateUpdateOrder;

public class CreateUpdateOrderValidator : AbstractValidator<CreateUpdateOrderCommand>
{
    public CreateUpdateOrderValidator()
    {
        RuleFor(command => command.Number).NotNull();
        RuleFor(command => command.Date).NotNull();
        RuleFor(command => command.ProviderId).NotNull();
    }
}