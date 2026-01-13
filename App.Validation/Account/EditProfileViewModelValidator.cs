using App.Models.ViewModels;
using FluentValidation;

namespace App.Validation;

public class EditProfileViewModelValidator : AbstractValidator<EditProfileViewModel>
{
    public EditProfileViewModelValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^\d+$").WithMessage("Phone number can only contain digits");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("State is required");

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal Code is required");

        RuleFor(x => x.StreetAddress)
            .NotEmpty().WithMessage("Street Address is required");
    }
}