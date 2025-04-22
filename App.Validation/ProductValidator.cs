using App.Models;
using FluentValidation;

namespace App.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        
    }
}