using System.Data;
using App.Models;
using FluentValidation;

namespace App.Validation;

public class AppUserValidator : AbstractValidator<AppUser>
{
    public AppUserValidator()
    {
        
    }
}