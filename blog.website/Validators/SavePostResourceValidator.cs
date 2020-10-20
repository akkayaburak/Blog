using blog.website.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.website.Validators
{
    public class SavePostResourceValidator : AbstractValidator<SavePostDTO>
    {
        public SavePostResourceValidator()
        {
            RuleFor(m => m.Context)
                .NotEmpty()
                .MaximumLength(180);

            RuleFor(m => m.UserId)
                .NotEmpty()
                .WithMessage("'User Id' must not be 0");
        }
    }
}
