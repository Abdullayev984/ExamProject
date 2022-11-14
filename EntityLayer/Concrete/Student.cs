using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Student
    {
        [Key]

        public int? StudentId { get; set; }

        public string StudentName { get; set; }

        public string StudentSurname { get; set; }

        public int Grade { get; set; }

        public bool IsDeleted { get; set; }
    }
}
