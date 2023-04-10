using FluentValidation;

namespace Application.Commands.Provider.CreateProvider;

public class CreateProviderValidator : AbstractValidator<CreateProviderCommand>
{
    public CreateProviderValidator()
    {
        RuleFor(x => x.Name).NotNull();
    }
}