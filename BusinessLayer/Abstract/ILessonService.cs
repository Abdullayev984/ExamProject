using EntityLayer.DTOs.LessonDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILessonService
    {
        Task<LessonToListDTO> Add(LessonToAddorUpdateDTO lesson);
        Task<LessonToListDTO> Update(LessonToAddorUpdateDTO lesson);
        Task<LessonToListDTO> Get(int lessonId);
        Task<List<LessonToListDTO>> Get();

        Task Delete(int lessonId);
    }
}
