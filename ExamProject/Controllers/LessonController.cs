using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.LessonDTOs;
using EntityLayer.DTOs.StudentDTOs;
using ExamProject.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ExamProject.Controllers
{

    public class LessonController : Controller
    {
        public readonly ILessonService _lessonService;
        public IMapper _mapper;


        public LessonController(ILessonService lessonService, IMapper mapper)
        {

            _lessonService = lessonService;
            _mapper = mapper;


        }

        public async Task<IActionResult> Index()
        {
            List<LessonToListDTO> lessons = await _lessonService.Get();
            return View(lessons);
        }
        public async Task<IActionResult> CreateLesson(int? lessonId)
        {

            List<LessonToListDTO> lessons = await _lessonService.Get();
            var data = lessons.FirstOrDefault(m => m.LessonId == lessonId);
            return View(_mapper.Map<LessonToAddorUpdateDTO>(data));
        }
        public async Task<IActionResult> AddLesson(LessonToAddorUpdateDTO lesson)
        {

            LessonValidatior validationRules = new LessonValidatior();
            ValidationResult results = validationRules.Validate(lesson);

            if (results.IsValid)
            {
                try
                {
                    if (lesson.LessonId == null)
                    {
                        await _lessonService.Add(lesson);
                    }
                    else
                    {

                        await _lessonService.Update(lesson);



                    }
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewBag.mesage = "Lessoncode and Grade must be unique together";

                    return View("CreateLesson", lesson);
                }


            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("CreateLesson", lesson);
            }



        }
        public async Task<IActionResult> Delete(int id)
        {

            await _lessonService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
