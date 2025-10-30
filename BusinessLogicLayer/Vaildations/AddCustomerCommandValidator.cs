using BusinessLogicLayer.Commends.Custmers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Vaildations
{
    public class AddCustomerCommandValidator: AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100)
                .WithMessage("Name cannot exceed 100 characters");
            RuleFor(x => x.Email)
                   .NotEmpty().WithMessage("Email is required")
                   .Matches(@"^[A-Za-z][A-Za-z0-9._%+-]*@(gmail|yahoo|outlook)\.com$")
                   .WithMessage("Email must start with a letter and be a valid Gmail, Yahoo, or Outlook address (e.g., amira@gmail.com)")
                   .MaximumLength(100).WithMessage("Email cannot exceed 100 characters");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required")
               
                .Matches(@"^[0-9]{10,15}$").WithMessage("Phone must contain only numbers (10–15 digits).");
            RuleFor(x => x.Address)
                .NotEmpty()
                                .WithMessage("Address is required")
                .MaximumLength(200)
                .WithMessage("Address cannot exceed 200 characters");

        }
    }
}
