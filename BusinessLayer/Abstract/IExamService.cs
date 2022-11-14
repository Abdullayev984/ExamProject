using EntityLayer.DTOs.ExamDTOs;

namespace BusinessLayer.Abstract
{
    public interface IExamService
    {
        Task<ExamToListDTO> Add(ExamToAddorUpdateDTO examToAddorUpdateDTO);
        Task<ExamToListDTO> Update(ExamToAddorUpdateDTO examToAddorUpdateDTO);
        Task<ExamToListDTO> Get(int examId);
        Task<List<ExamToListDTO>> Get();
        Task Delete(int examId);
    }
}
