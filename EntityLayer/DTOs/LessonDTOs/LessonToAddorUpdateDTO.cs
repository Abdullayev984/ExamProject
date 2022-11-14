namespace EntityLayer.DTOs.LessonDTOs
{
    public class LessonToAddorUpdateDTO
    {
        public int? LessonId { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public int Grade { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
    
    }
}
