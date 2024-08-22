using Blog.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Validations
{
	public class UserValidator:AbstractValidator<AppUser>
	{
        public UserValidator()
        {
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("Name can't be empty").MinimumLength(2).WithMessage("Name must be at least 2 characters").MaximumLength(30).WithMessage("Name can't be more than 30 characters ");
            RuleFor(x=>x.LastName).NotEmpty().
                WithMessage("Surname can't be empty").MinimumLength(2).WithMessage("Surname must be at least 2 characters").MaximumLength(30).WithMessage("Name can't be more than 30 characters ");
            RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Number can't be empty").
                MinimumLength(11).WithMessage("Number must be at least 11 characters").MaximumLength(30).WithMessage("Number can't be more than 30 characters ");
		}
    }
}
