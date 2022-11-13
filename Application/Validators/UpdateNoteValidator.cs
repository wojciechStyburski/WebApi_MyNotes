using Application.Dto;
using Domain.Interfaces;
using FluentValidation;

namespace Application.Validators;

public class UpdateNoteValidator : AbstractValidator<UpdateNoteDto>
{
    public UpdateNoteValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(n => n.Title)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(n => n.Title)
            .MaximumLength(2000);

        RuleFor(n => n.CategoryId)
            .NotEmpty()
            .Custom((value, context) =>
            {
                var categoryInUse = categoryRepository.GetById(value);

                if (categoryInUse == null)
                {
                    context.AddFailure("Category", $"Category with id: {value} not found");
                }
            });
    }
}