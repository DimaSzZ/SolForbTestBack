using FluentValidation;

namespace Application.Commands.OrderItemActions.CreateUpdateItem;

public class CreateUpdateItemValidator : AbstractValidator<CreateUpdateItemCommand>
{
    public CreateUpdateItemValidator()
    {
        RuleFor(command => command.OrderId).NotNull();
    }
}