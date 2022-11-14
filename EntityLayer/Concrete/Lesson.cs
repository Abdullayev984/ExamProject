using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{

    public class Lesson
    {
        [Key]
        
        public int? LessonId { get; set; }
        
        public string LessonCode { get; set; }

        public string LessonName { get; set; }
        public int Grade { get; set; }

        public string TeacherName { get; set; }
      
        public string TeacherSurname { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
