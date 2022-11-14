using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;

using EntityLayer.Concrete;




namespace DataAccessLayer.Concrete.EntityFramework
{
    public class ExamRepository : GenericRepository<Exam>,IExamRepository
    {
        public ExamRepository(DatabaseContext dataContext) : base(dataContext)
        {
        }
    }
}
