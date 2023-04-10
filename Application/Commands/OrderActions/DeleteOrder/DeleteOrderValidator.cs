using FluentValidation;

namespace Application.Commands.OrderActions.DeleteOrder;

public class DeleteOrderValidator: AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderValidator()
    {
        RuleFor(command => command.Id).NotNull();
    }
}