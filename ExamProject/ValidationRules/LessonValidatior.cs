using EntityLayer.DTOs.ExamDTOs;
using EntityLayer.DTOs.LessonDTOs;
using FluentValidation;

namespace ExamProject.ValidationRules
{
    public class LessonValidatior : AbstractValidator<LessonToAddorUpdateDTO>
    {
        public LessonValidatior()
        {
            RuleFor(x => x.TeacherSurname).MinimumLength(5).WithMessage("min length must be 5 characters");
            RuleFor(x => x.LessonCode).NotEmpty().WithMessage("not null");
        }
    }
    }

