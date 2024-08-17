using Blog.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Validations
{
	public class ArticleValidator:AbstractValidator<Article>
	{
        public ArticleValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Title can't be empty")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters")
                .MaximumLength(150).WithMessage("Title must be less than 150 characters");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content can't be empty")
                .MinimumLength(10).WithMessage("Content must be at least 10 characters");
        }
    }
}
