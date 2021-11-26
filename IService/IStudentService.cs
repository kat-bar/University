using System.Collections.Generic;
using University.Models;

namespace University.IService
{
    public interface IStudentService
    {
        Student Save(Student oStudent);
        IEnumerable<Student> GetSavedStudent();
        Student Update(Student oStudent);
    }
}
