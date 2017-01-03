using FluentValidation;
using MVC_CRUD.Models;

namespace MVC_CRUD.Validation
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(c => c.FirstName).NotEmpty().Length(0, 10);
            RuleFor(c => c.LastName).NotEmpty().Length(0, 10);
            RuleFor(c => c.Phone).Length(11).WithMessage("Enter valid Number");
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Email Address is Required")
                .EmailAddress()
                .WithMessage("A valid Email is Required");
        }
    }
}
