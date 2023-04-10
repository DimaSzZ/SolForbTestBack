using FluentValidation;

namespace Application.Commands.OrderItemActions.DeleteItem;

public class DeleteItemValidator : AbstractValidator<DeleteItemCommand>
{
    public DeleteItemValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}