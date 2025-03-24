using App.Models;
using FluentValidation;

namespace App.Validation.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        
    }
}