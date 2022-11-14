
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;


using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class LessonRepository : GenericRepository<Lesson>,ILessonRepository
    {
        public LessonRepository(DatabaseContext dataContext) : base(dataContext)
        {
        }
    }
}