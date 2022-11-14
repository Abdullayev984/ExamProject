using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.ExamDTOs;
using EntityLayer.DTOs.StudentDTOs;
using ExamProject.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ValidationRules;

namespace ExamProject.Controllers
{
    public class ExamController : Controller
    {
        public readonly IExamService _examService;
        public IMapper _mapper;


        public ExamController(IExamService examService, IMapper mapper)
        {

            _examService = examService;
            _mapper = mapper;


        }

        public async Task<IActionResult> Index()
        {
            List<ExamToListDTO> exams = await _examService.Get();
            return View(exams);
        }
        public async Task<IActionResult> CreateExam(int? examId)
        {

            List<ExamToListDTO> exams = await _examService.Get();
            var data = exams.FirstOrDefault(m => m.ExamId == examId);
            return View(_mapper.Map<ExamToAddorUpdateDTO>(data));
        }
        public async Task<IActionResult> AddExam(ExamToAddorUpdateDTO exam)
        {

            ExamValidatior validationRules = new ExamValidatior();
            ValidationResult results = validationRules.Validate(exam);

            if (results.IsValid)
            {
                try
                {
                    if (exam.ExamId == null)
                    {
                        await _examService.Add(exam);
                    }
                    else
                    {

                        await _examService.Update(exam);



                    }

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewBag.mesage = "Lessoncode and StudentId must be unique together";

                    return View("CreateExam", exam);

                }


            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }


            return View("CreateExam", exam);


        }



        public async Task<IActionResult> Delete(int id)
        {

            await _examService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

