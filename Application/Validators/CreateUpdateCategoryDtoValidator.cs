using Application.Dto;
using Domain.Interfaces;
using FluentValidation;

namespace Application.Validators;

public class CreateUpdateCategoryDtoValidator : AbstractValidator<CreateUpdateCategoryDto>
{
    public CreateUpdateCategoryDtoValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(c => c.Name)
            .MaximumLength(50)
            .NotEmpty()
            .Custom((value, context) =>
            {
                var categoryNameInUse = categoryRepository.GetByName(value);
                if(categoryNameInUse != null)
                    context.AddFailure("Category", $"Category with name: {value} exists, name must be unique.");
            });
    }
}