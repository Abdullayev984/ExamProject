using EntityLayer.DTOs.StudentDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationRules
{
    public class StudentValidatior:
   AbstractValidator<StudentToAddorUpdateDTO>
    {
        public StudentValidatior()
        {
            RuleFor(x => x.StudentName).MinimumLength(3).WithMessage("min length must be 3");
            RuleFor(x => x.StudentSurname).MaximumLength(20).WithMessage("max length must be 20");
            RuleFor(x => x.Grade).NotEmpty().WithMessage("can not be null");

        }
}
}

