using FluentValidation;
using MiniECommerce.Application.Dtos.CategoryDtos;
using MiniECommerce.Domain.Concrete;
using System;
using System.Collections.Generic;
using System
    .Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application.Validations.CategoryValidations;

public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidation()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
        RuleFor(c => c.Name).MaximumLength(250).WithMessage("Açıklmama en fazla 250 karakter uzunluğunda olmalıdır");
    }
}
