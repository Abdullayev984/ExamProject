using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;

using EntityLayer.Concrete;


using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class StudentRepository : GenericRepository<Student>,IStudentRepository
    {
        public StudentRepository(DatabaseContext dataContext) : base(dataContext)
        {
        }
    }
}

