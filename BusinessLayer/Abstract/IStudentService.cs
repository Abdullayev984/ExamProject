using EntityLayer.DTOs.StudentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentService
    {
        Task<StudentToListDTO> Add(StudentToAddorUpdateDTO studentToAddorUpdateDTO);
        Task<StudentToListDTO> Update(StudentToAddorUpdateDTO studentToAddorUpdateDTO);
        Task<StudentToListDTO> Get(int studentId);
        Task<List<StudentToListDTO>> Get();
        Task Delete(int studentId);
    }
}
