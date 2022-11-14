using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{

    public class Exam
    {
        [Key]
        public int? ExamId { get; set; }

        public string LessonCode { get; set; }

        public int StudentId { get; set; }

        public DateTime ExamDate { get; set; } = DateTime.Now;

        public int Score { get; set; }
        public bool IsDeleted { get; set; }
    }
}
