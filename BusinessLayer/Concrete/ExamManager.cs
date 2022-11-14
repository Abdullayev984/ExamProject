using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using EntityLayer.DTOs.ExamDTOs;

namespace BusinessLayer.Concrete
{
    public class ExamManager : IExamService
    {
        private readonly IGenericRepository<Exam> _examRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public ExamManager(IGenericRepository<Exam> examRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            _databaseContext = databaseContext; 
        }
        public async Task<ExamToListDTO> Add(ExamToAddorUpdateDTO examToAddorUpdateDTO)
        {
            Exam exam = await _examRepository.Add(_mapper.Map<Exam>(examToAddorUpdateDTO));
            return _mapper.Map<ExamToListDTO>(exam);
        }

        public async Task Delete(int examId)
        {
            Exam exam = await _examRepository.Get(examId);
            exam.IsDeleted = true; 
            await _databaseContext.SaveChangesAsync();
          
        }

        public async Task<ExamToListDTO> Get(int examId)
        {
            Exam exam = await _examRepository.Get(examId);
            return _mapper.Map<ExamToListDTO>(exam);
        }

        public async Task<List<ExamToListDTO>> Get()
        {
            List<Exam> exams = await _examRepository.Get();
            return _mapper.Map<List<ExamToListDTO>>(exams);

        }

        public async Task<ExamToListDTO> Update(ExamToAddorUpdateDTO examToAddorUpdateDTO)
        {
            Exam exam = await _examRepository.Update(_mapper.Map<Exam>(examToAddorUpdateDTO));
            return _mapper.Map<ExamToListDTO>(exam);
        }
    }
}
