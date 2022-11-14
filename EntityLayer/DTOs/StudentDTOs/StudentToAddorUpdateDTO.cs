using System.ComponentModel.DataAnnotations;

namespace EntityLayer.DTOs.StudentDTOs
{
    public class StudentToAddorUpdateDTO
    {

        public int? StudentId { get; set; }

        public string StudentName { get; set; }

        public string StudentSurname { get; set; }

        public int Grade { get; set; }


    }
}
