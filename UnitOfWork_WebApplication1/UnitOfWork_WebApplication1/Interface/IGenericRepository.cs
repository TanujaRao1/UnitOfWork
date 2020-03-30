using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWork_WebApplication1.Interface
{
    public interface IGenericRepository<T> where T: class
    {
        IList<T> GetAll();
        T GetById(int studentId, int courseId);
        void Insert(T student);
        void Update(T student);
        void Delete(T student);
    }
}
