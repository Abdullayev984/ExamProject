using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs.ExamDTOs
{
    public class ExamToListDTO
    {
        public int? ExamId { get; set; }
   
        public string LessonCode { get; set; }
        public int StudentId { get; set; }
        public DateTime ExamDate { get; set; } = DateTime.Now;
        public int Score { get; set; }

    }
}
