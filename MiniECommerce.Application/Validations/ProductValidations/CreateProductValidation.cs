using FluentValidation;
using MiniECommerce.Dtos.ProductDtos;

namespace MiniECommerce.Application.Validations.ProductValidations;

public class CreateProductValidation : AbstractValidator<CreateProductDto>
{
    public CreateProductValidation()
    {
        RuleFor(a => a.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez");
        RuleFor(a => a.Description).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez").MaximumLength(500).WithMessage("Ürün açıklaması en fazla 500 karakter olmalıdır");
        RuleFor(a => a.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");
        RuleFor(a => a.Stock).NotEmpty().WithMessage("Ürün stok durumu boş geçilemez");
        RuleFor(a => a.CategoryId).NotEmpty().WithMessage("Ürün kategorisi boş geçilemez");
    }
}
