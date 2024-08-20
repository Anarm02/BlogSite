using Blog.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Validations
{
	public class CategoryValidator:AbstractValidator<Category>
	{
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Category name can't be empty")
                .MinimumLength(3).WithMessage("Category name must be at least 3 characters")
                .MaximumLength(100).WithMessage("Category name must be less than 101 characters");
        }
    }
}
