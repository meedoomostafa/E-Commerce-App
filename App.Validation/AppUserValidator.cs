using System.Data;
using App.Models;
using FluentValidation;

namespace App.Validation.Validators;

public class AppUserValidator : AbstractValidator<AppUser>
{
    public AppUserValidator()
    {
        
    }
}