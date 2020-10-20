using blog.website.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.website.Validators
{
    public class SaveUserResourceValidator : AbstractValidator<SaveUserDTO>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
