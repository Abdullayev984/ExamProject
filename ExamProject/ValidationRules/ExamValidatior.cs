using EntityLayer.DTOs.ExamDTOs;
using FluentValidation;

namespace ExamProject.ValidationRules
{
    public class ExamValidatior:AbstractValidator<ExamToAddorUpdateDTO>
    {
        public ExamValidatior()
        {
            RuleFor(x => x.LessonCode).MaximumLength(5).WithMessage("Max length must be 5 characters");
            RuleFor(x => x.LessonCode).MinimumLength(1).WithMessage("min length must be 1 character");
            RuleFor(x => x.LessonCode).NotEmpty().WithMessage("not null");


        }
    }
}
