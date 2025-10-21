using FluentValidation;
using MiniECommerce.Dtos.CategoryDtos;

namespace MiniECommerce.Application.Validations.CategoryValidations;

public class AddCategoryValidation : AbstractValidator<CreateCategoryDto>
{
    public AddCategoryValidation()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
        RuleFor(c => c.Name).MaximumLength(250).WithMessage("Açıklmama en fazla 250 karakter uzunluğunda olmalıdır");
    }
}
