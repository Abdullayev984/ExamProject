using EntityLayer.DTOs.UserDTOs;
using FluentValidation;

namespace ExamProject.ValidationRules
{
    public class UserValidatior :AbstractValidator<RegisterViewModel>
    {
        public UserValidatior()
        {
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("password min length must be 6");
            RuleFor(x => x.Password).Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.");
            RuleFor(x => x.Password).Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.");
            RuleFor(x => x.Password).Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
            RuleFor(x => x.Password).Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.)");

        }
}
}
