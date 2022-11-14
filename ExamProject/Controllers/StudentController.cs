using AutoMapper;
using BusinessLayer.Abstract;

using EntityLayer.DTOs.StudentDTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ValidationRules;

namespace ExamProject.Controllers
{

    public class StudentController : Controller
    {
        public readonly IStudentService _studentService;

        public readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {

            _studentService = studentService;

            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<StudentToListDTO> students = await _studentService.Get();
            return View(students);
        }
        public async Task<IActionResult> CreateStudent(int? id)
        {

            List<StudentToListDTO> students = await _studentService.Get();
            var data = students.FirstOrDefault(m => m.StudentId == Convert.ToInt32(id));
            return View(_mapper.Map<StudentToAddorUpdateDTO>(data));
        }
        public async Task<IActionResult> AddStudent(StudentToAddorUpdateDTO student)
        {
            StudentValidatior validationRules = new StudentValidatior();
            ValidationResult results = validationRules.Validate(student);

            if (results.IsValid)
            {
                if (student.StudentId == null)
                {
                    await _studentService.Add(student);
                }
                else
                {

                    await _studentService.Update(student);

                }
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }


            return View("CreateStudent", student);


        }



        public async Task<IActionResult> Delete(int id)
        {

            await _studentService.Delete(Convert.ToInt32(id));

            return RedirectToAction("Index");
        }
    }
}
