using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs.StudentDTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BusinessLayer.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public StudentManager(IGenericRepository<Student> studentRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public async Task<StudentToListDTO> Add(StudentToAddorUpdateDTO studentToAddorUpdateDTO)
        {
           
                Student student = await _studentRepository.Add(_mapper.Map<Student>(studentToAddorUpdateDTO));
                return _mapper.Map<StudentToListDTO>(student);
            
           
        }

        public async Task Delete(int studentId)
        {
            Student student = await _studentRepository.Get(studentId);
            student.IsDeleted = true;
            await _databaseContext.SaveChangesAsync();
        }

        public Task<StudentToListDTO> Get(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentToListDTO>> Get()
        {
            List<Student> students = await _studentRepository.Get();
            return _mapper.Map<List<StudentToListDTO>>(students);
        }

        public async Task<StudentToListDTO> Update(StudentToAddorUpdateDTO studentToAddorUpdateDTO)
        {
            Student student = await _studentRepository.Update(_mapper.Map<Student>(studentToAddorUpdateDTO));
            return _mapper.Map<StudentToListDTO>(student);
        }
    }
}
