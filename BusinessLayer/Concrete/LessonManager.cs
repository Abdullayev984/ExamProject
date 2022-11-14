using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs.LessonDTOs;

namespace BusinessLayer.Concrete
{
    public class LessonManager : ILessonService
    {
        private readonly IGenericRepository<Lesson> _lessonRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public LessonManager(IGenericRepository<Lesson> lessonRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public async Task<LessonToListDTO> Add(LessonToAddorUpdateDTO lessonToAddorUpdateDTO)
        {
            Lesson lesson = await _lessonRepository.Add(_mapper.Map<Lesson>(lessonToAddorUpdateDTO));
            return _mapper.Map<LessonToListDTO>(lesson);
        }

        public async Task Delete(int lessonId)
        {
            Lesson lesson = await _lessonRepository.Get(lessonId);
            lesson.IsDeleted = true;
            await _databaseContext.SaveChangesAsync();
            
        }

        public async Task<LessonToListDTO> Get(int lessonId)
        {
            Lesson lesson = await _lessonRepository.Get(lessonId);
            return _mapper.Map<LessonToListDTO>(lesson);
        }

        public async Task<List<LessonToListDTO>> Get()
        {
            List<Lesson> lessons = await _lessonRepository.Get();
            return _mapper.Map<List<LessonToListDTO>>(lessons);

        }

        public async Task<LessonToListDTO> Update(LessonToAddorUpdateDTO lessonToAddorUpdateDTO)
        {
            Lesson lesson = await _lessonRepository.Update(_mapper.Map<Lesson>(lessonToAddorUpdateDTO));
            return _mapper.Map<LessonToListDTO>(lesson);
        }
    }
}
